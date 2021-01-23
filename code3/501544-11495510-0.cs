    class YourClass 
    {
         // a member declared by a class-member-declaration
         WebClient webClient = new WebClient();
    
        private void button1_Click(object sender, EventArgs e)
        {
            //a local variable 
            WebClient otherWebClient = new WebClient();
            webClient.DownloadFileAsync(new Uri(textBox1.Text), destination);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // here is out of otherWebClient scope
            // but scope of webClient not ended
            webClient.CancelAsync();
        }
   
    }
