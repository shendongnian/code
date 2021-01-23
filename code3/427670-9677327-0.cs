    Dim boundry As String = "---------------------------" + DateTime.Now.Ticks.ToString("x")
        Dim request As WebRequest = WebRequest.Create(Globals.script_path + "uploader.php")
        request.Method = "POST"
        request.ContentType = "multipart/form-data; boundary=" + boundry
        Dim requestStream As Stream = request.GetRequestStream()
        '' send text data
        Dim data As Hashtable = New Hashtable()
        data.Add("text_input", "Hello World")
        For Each key As String In data.Keys
            Dim item As String = "--" + boundry + vbCrLf + "Content-Disposition: form-data; name=""" & key & """" + vbCrLf + vbCrLf + data.Item(key) + vbCrLf
            Dim itemBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(item)
            requestStream.Write(itemBytes, 0, itemBytes.Length)
        Next
        '' send image data
        Dim file_header = "--" + boundry + vbCrLf + "Content-Disposition: form-data; name=""file_1"";filename=""file.png""" + vbCrLf + "Content-Type: image/png" + vbCrLf + vbCrLf
        Dim file_header_bytes() As Byte = System.Text.Encoding.UTF8.GetBytes(file_header)
        requestStream.Write(file_header_bytes, 0, file_header_bytes.Length)
        Dim ms As MemoryStream = New MemoryStream()
        timecard.screen_shot.Save(ms, ImageFormat.Png)
        Dim file_bytes() As Byte = ms.GetBuffer()
        ms.Close()
        requestStream.Write(file_bytes, 0, file_bytes.Length)
        Dim file_footer_bytes() As Byte = System.Text.Encoding.UTF8.GetBytes(vbCrLf)
        requestStream.Write(file_footer_bytes, 0, file_footer_bytes.Length)
        '' send
        Dim endBytes() As Byte = System.Text.Encoding.UTF8.GetBytes("--" + boundry + "--")
        requestStream.Write(endBytes, 0, endBytes.Length)
        requestStream.Close()
        Dim response As WebResponse = request.GetResponse()
        Dim reader As StreamReader = New StreamReader(response.GetResponseStream())
        Debug.WriteLine(reader.ReadToEnd())
