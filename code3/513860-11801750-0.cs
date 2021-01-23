    Dim c As New System.Net.WebClient
    Dim FileName As String = "c:\StackOverflow.png"
    c.DownloadFile(New System.Uri("http://cdn.sstatic.net/stackoverflow/img/sprites.png?v=5"), FileName)
    Dim img As System.Drawing.Image
    img = System.Drawing.Image.FromFile(FileName)
