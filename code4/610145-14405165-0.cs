        private void btnClip_Click(object sender, EventArgs e)
        {
            string address = "http://animalrights.about.com/";
            string text = "";
            // Retrieve resource as a stream
            Stream data = client.OpenRead(new Uri(address)); //client here is a WebClient
            //create document
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.Load(data);
            //receive all the text fields
            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//child::p"))
            {
                text += node.InnerText + "\n\n";
            }
            Clipboard.SetText(text);
            string path = @"C:\Users\David\Documents\Visual Studio 2012\Projects\CopyToClipBoard\CopyToClipBoard\bin\MyTest.txt";
            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            // Create the file.
            using (FileStream fs = File.Create(path, 1024))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(text);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
            //destroy data object
            data.Close();
            data.Dispose();
        }
