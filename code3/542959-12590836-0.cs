    Public Class Form1
        Public Sub New()
            InitializeComponent()
            PictureBox1.Dock = DockStyle.Fill
            image = New System.Drawing.Imaging.Metafile(New System.IO.MemoryStream(My.Resources.schoolbus))
        End Sub
    
        Private Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
            e.Graphics.DrawImage(image, New Rectangle(Point.Empty, PictureBox1.ClientSize))
        End Sub
    
        Private Sub PictureBox1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Resize
            PictureBox1.Invalidate()
        End Sub
    
        Private image As System.Drawing.Imaging.Metafile
    
    End Class
