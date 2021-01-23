     try{
            String url = textBox1.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(sr);
            var aTags = doc.DocumentNode.SelectNodes("//a");
            int counter = 1;
            if (aTags != null)
            {
                foreach (var aTag in aTags)
                {
                    richTextBox1.Text +=  aTag.InnerHtml +  "\n" ;
                    counter++;
                }
            }
            sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve related keywords." + ex);
            }
