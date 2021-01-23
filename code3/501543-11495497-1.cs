    class SomeClass {
        WebClient webClient = new WebClient();
    
        private void button1_Click(object sender, EventArgs e)
        {
            ...
            webClient.DownloadFileAsync(new Uri(textBox1.Text), destination);
        }
    }
