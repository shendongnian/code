    Imports AForge.Video
    Imports AForge.Video.VFW
    '…
    Dim VideoStream As MJPEGStream = New MJPEGStream("<your MJPEG URL>")
    Dim VFWriter = New AVIWriter(("your compression codec 4CC ex:xvid>"))
    VFWriter.FrameRate = <framerate>
    
    AddHandler VideoStream.NewFrame, AddressOf NewStreamFrame '<Your Handler>
    
    '…
    
    Public Sub StartRecording()
    VFWriter.Open("<destinationFile.avi>", <FrameSize.Width>, <FrameSize.Height>)
    ‘FrameSize.Width and height must correspond to what your camera is sending
           VideoStream.Start()
    End Sub
    
    Public Sub StopRecording()
            VFWriter.Close()
    End Sub
    
    
    Private Sub NewStreamFrame(sender As System.Object, e As NewFrameEventArgs)
            VFWriter.AddFrame(e.Frame)
    End Sub
