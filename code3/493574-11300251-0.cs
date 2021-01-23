    Imports System.Drawing.Drawing2D
    
    Public MustInherit Class ShipShape
        Public Layout As New Rectangle(0, 0, 128, 128)
        Public MustOverride Sub Draw(ByVal g As Graphics)
    
        Public Shared Sub DrawRoundedRectangle(ByVal gp As GraphicsPath, ByVal r As Rectangle, ByVal d As Integer)
            gp.AddArc(r.X, r.Y, d, d, 180, 90)
            gp.AddLine(CInt(r.X + d / 2), r.Y, CInt(r.X + r.Width - d / 2), r.Y)
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90)
            gp.AddLine(CInt(r.X + r.Width), CInt(r.Y + d / 2), CInt(r.X + r.Width), CInt(r.Y + r.Height - d / 2))
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90)
            gp.AddLine(CInt(r.X + d / 2), CInt(r.Y + r.Height), CInt(r.X + r.Width - d / 2), CInt(r.Y + r.Height))
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90)
            gp.AddLine(r.X, CInt(r.Y + d / 2), r.X, CInt(r.Y + r.Height - d / 2))
        End Sub
    
        Public Shared Sub main()
            Dim b As New Bitmap(640, 480)
            Dim g As Graphics = Graphics.FromImage(b)
            g.Clear(Color.Magenta)
            Dim Hull As New HullShape
            Hull.Layout = New Rectangle(640 * 0.5 - 128 * 0.5, 480 * 0.5 - 128 * 0.5, 128, 128)
            Hull.Draw(g)
            Dim Wing1 As New HullShape
            Wing1.Layout = New Rectangle(Hull.Layout.X - 32, Hull.Layout.Y - 32, 32, Hull.Layout.Height + 64)
            Wing1.Draw(g)
            Dim Wing2 As New HullShape
            Wing2.Layout = New Rectangle(Hull.Layout.X + Hull.Layout.Width, Hull.Layout.Y - 32, 32, Hull.Layout.Height + 64)
            Wing2.Draw(g)
            b.Save("test.png")
        End Sub
    
    End Class
    
    Public Class HullShape
        Inherits ShipShape
        Public Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
            Dim gp As New GraphicsPath
            ShipShape.DrawRoundedRectangle(gp, Layout, 30)
            Dim MetalBrush As New LinearGradientBrush(Layout, Color.Gainsboro, Color.Gray, 0)
            g.FillPath(MetalBrush, gp)
            g.DrawPath(Pens.Black, gp)
        End Sub
    End Class
