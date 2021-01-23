    Private Sub ToolTip1_Draw(sender As Object, e As DrawToolTipEventArgs) Handles ToolTip1.Draw
        Dim tt As ToolTip = CType(sender, ToolTip)
        Dim b As Brush = New SolidBrush(tt.BackColor)
    
        e.Graphics.FillRectangle(b, e.Bounds)
    
        Dim sf As StringFormat = New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        e.Graphics.DrawString(e.ToolTipText, SystemFonts.DefaultFont, SystemBrushes.ActiveCaptionText, e.Bounds, sf)
        sf.Dispose()
        b.Dispose()
    End Sub
