        async void doLoadBG()
        {
            System.Xml.Linq.XDocument xmlDoc = XDocument.Load("http://www.bing.com/HPImageArchive.aspx?format=xml&idx=0&n=1&mkt=en-US");
            IEnumerable<string> strTest = from node in xmlDoc.Descendants("url") select node.Value;
            string strURL = "http://www.bing.com" + strTest.First();
            Uri source = new Uri(strURL);
            StorageFile destinationFile;
            try
            {
                destinationFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                    "downloadimage.jpg", CreationCollisionOption.GenerateUniqueName);
            }
            catch (FileNotFoundException ex)
            {
                return;
            }
            BackgroundDownloader downloader = new BackgroundDownloader();
            DownloadOperation download = downloader.CreateDownload(source, destinationFile);
            await download.StartAsync();
            ResponseInformation response = download.GetResponseInformation();
            Uri imageUri;
            BitmapImage image = null;
            if (Uri.TryCreate(destinationFile.Path, UriKind.RelativeOrAbsolute, out imageUri))
            {
                image = new BitmapImage(imageUri);
            }
            imgBrush.ImageSource = image;
        }
