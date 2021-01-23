       if (saveFileDialog1.ShowDialog() == DialogResult.OK)
       {
    
           try
           {
               WebClient webClient = new WebClient();
               byte[] receivedData = webClient.DownloadData("http://startut.ro/smartAppointment.rar");
               FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
               BinaryWriter bw = new BinaryWriter(fs);
    
               bw.Write(receivedData);
    
               bw.Close();
               fs.Close();
               ((IDisposable)fs).Dispose();//Dispose of the FileStream
           }
           catch (Exception e)
           {
               string message = e.Message;
               MessageBox.Show("Nu ai o conexiune de internet stabilită. Încearcă să te conectezi la internet, și după aceea să descarci noua versiune !", "EROARE CONEXIUNE INTERNET");
           }
    
       }
