    Private Sub DataRepeater1_DrawItem(sender As Object, e As PowerPacks.DataRepeaterItemEventArgs) Handles DataRepeater1.DrawItem
    
      Dim pic As PictureBox = CType(e.DataRepeaterItem.Controls("PictureBox1"), System.Windows.Forms.PictureBox)
    
      Dim txt As TextBox = CType(e.DataRepeaterItem.Controls("txtBox1"), System.Windows.Forms.TextBox)
    
      Pic.ImageLocation = txt.Text
    
    End Sub
