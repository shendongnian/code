    foreach (Article article in NewsList.Result.Articles)
    {
        NewsListBoxItem NLBI = new NewsListBoxItem();
        NLBI.Title.Text = article.Title;
        NLBI.Date.Text = US.UnixDateToNormal(article.Date.ToString());
        NLBI.id.Text = article.Id.ToString();
        if (article.ImageURL != null)
        {
            BitmapImage image = new BitmapImage(new Uri(article.ImageURL));
            image.ImageOpened += (s, e) =>
                {
                    byte[] bytearray = null;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        WriteableBitmap wbitmp = new WriteableBitmap(image );
                        wbitmp .SaveJpeg(ms, wbitmp.PixelWidth, wbitmp.PixelHeight, 0, 100);
                        bytearray = ms.ToArray();
                    }
                    string str = Convert.ToBase64String(bytearray);
                };
            NLBI.Thumbnail.Source = image;
        }
        NewsListBox.Items.Add(NLBI);
    }
