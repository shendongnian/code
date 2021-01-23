    Private Sub pickColor(ByVal sender As Object, ByVal e As MouseEventArgs) _
                          Handles picBox.MouseClick
      Using bmp As New Bitmap(picBox.ClientSize.Width, _
                              picBox.ClientSize.Height)
        picBox.DrawToBitmap(bmp, picBox.ClientRectangle)
        MessageBox.Show(bmp.GetPixel(e.X, e.Y).ToString())
      End Using
    End Sub
