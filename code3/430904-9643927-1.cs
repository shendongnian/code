        public ActionResult GetImg(float rate)
        {
            WebClient client = new WebClient();
            byte[] imgContent = client.DownloadData("ImgUrl");
            WebImage img = new WebImage(imgContent);
            img.Resize((int)(img.Width * rate), (int)(img.Height * rate));
            img.Write();
            return null;
        }
