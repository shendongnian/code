    Dim req As System.Net.WebRequest = System.Net.WebRequest.Create("[URL here]")
    Dim response As System.Net.WebResponse = req.GetResponse()
    Dim stream As Stream = response.GetResponseStream()
    
    Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(stream)
    stream.Close()
