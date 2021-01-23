            WebClient client = new WebClient();
            byte[] file = client.DownloadData("example.com");
            File.WriteAllBytes(@"example.txt", file);
            string[] lines = File.ReadAllLines("example.txt");
            richTextBox1.Text = lines;
