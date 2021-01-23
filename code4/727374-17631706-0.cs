    Imports System.Drawing.Drawing2D
    Public Class Form1
    
        Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    
            Dim pathPolygon As New GraphicsPath(FillMode.Winding)
            Dim pathEllipse As New GraphicsPath(FillMode.Winding)
    
            '------ POLYGON (X)
            Dim points() As Point = {New Point(5, 15), _
            New Point(10, 10), _
            New Point(18, 18), _
            New Point(26, 10), _
            New Point(31, 15), _
            New Point(23, 23), _
            New Point(31, 31), _
            New Point(26, 36), _
            New Point(18, 28), _
            New Point(10, 36), _
            New Point(5, 31), _
            New Point(13, 23)}
            Dim maxVals As New Point(31, 36)
    
            pathPolygon.AddPolygon(points)
    
            Dim region = New Region(pathPolygon)
    
            '------ POLYGON (X)
            With Me.Button1
                .BackColor = Color.Red
                .FlatAppearance.BorderSize = 0
                .FlatStyle = FlatStyle.Flat
                .Region = region
                .SetBounds(.Location.X, .Location.Y, maxVals.X, maxVals.Y)
            End With
    
            '------- ELLIPSE
            Dim ellipse As New Rectangle(0, 0, 100, 50)
            maxVals = New Point(100, 50)
            pathEllipse.AddEllipse(ellipse)
            region = New Region(pathEllipse)
            With Me.Button2
                .BackColor = Color.Red
                .FlatAppearance.BorderSize = 0
                .FlatStyle = FlatStyle.Flat
                .Region = region
                .SetBounds(.Location.X, .Location.Y, maxVals.X, maxVals.Y)
            End With
        End Sub
    End Class
