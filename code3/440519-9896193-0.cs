    Public Class Form3
    
        Public Sub New()
    
            InitializeComponent()
            Me.ContextMenuStrip = ContextMenuStrip1
    
        End Sub
    
        Private Sub ContextMenuStrip1_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Opened
            JSsetTimeout.SetTimeout(AddressOf PrintScreen, 600)
        End Sub
    
        Private Sub PrintScreen()
            Dim sc As New ScreenShot.ScreenCapture()
            Dim img As Image = sc.CaptureScreen
            img.Save(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "screenShot.png"), Imaging.ImageFormat.Png)
            JSsetTimeout.SetTimeout(AddressOf HideContextMenu, 600)
        End Sub
    
        Private Sub HideContextMenu()
            ContextMenuStrip1.Hide()
        End Sub
    
    End Class
