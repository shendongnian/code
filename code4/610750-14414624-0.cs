    private void SetImageAsBackground(string uri)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK && response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                {
                    Bitmap temp = new Bitmap(response.GetResponseStream());
                    this.BackgroundImage = temp;
                    this.Refresh();
                }
                else 
                {
                    MessageBox.Show("This isn't an image!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception: {0}", ex));                
            }
        }
