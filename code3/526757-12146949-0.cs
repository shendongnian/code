    WebClient webClient = new WebClient();    
    saveFileDialog1.ShowDialog();
    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler (FileDownloaded);//Implement this method to notify the download.
    
       if (saveFileDialog1.ShowDialog() == DialogResult.OK)
       {
    
           try
           {               
               webClient.DownloadFileAsync("http://startut.ro/smartAppointment.rar", saveFileDialog1.FileName);
           }
           catch (Exception e)
           {
               string message = e.Message;
               MessageBox.Show("Nu ai o conecsiune de internet stabilită. Încearcă să te conectezi la internet, și după aceea să descarci noua versiune !", "EROARE CONECSIUNE INTERNET");
           }
    
       }
    
