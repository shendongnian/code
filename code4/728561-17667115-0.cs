          System.Net.WebRequest request = System.Net.WebRequest.Create(YourURLString);
          System.Net.WebResponse resp = request.GetResponse();
          System.IO.Stream respStream = resp.GetResponseStream();
          Bitmap bmp = new Bitmap(respStream);
          respStream.Dispose();
          picturebox1.Image = bmp;
