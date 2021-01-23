    Public Class Form1
      Private _Images As New List(Of Image)
      Private _ImageIndex As Integer
    
      Public Sub New()
        InitializeComponent()
    
        For i As Integer = 1 To 3
          Dim bmp As New Bitmap(32, 32)
          Using g As Graphics = Graphics.FromImage(bmp)
            Select Case i
              Case 1 : g.Clear(Color.Blue)
              Case 2 : g.Clear(Color.Red)
              Case 3 : g.Clear(Color.Green)
            End Select
          End Using
          _Images.Add(bmp)
        Next
    
      End Sub
    
      Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PictureBox1.Click
        If _Images.Count > 0 Then
          PictureBox1.Image = _Images(_ImageIndex)
          _ImageIndex += 1
          If _ImageIndex > _Images.Count - 1 Then
            _ImageIndex = 0
          End If
        End If
      End Sub
    End Class
