	BackgroundWorker bw = new BackgroundWorker();
	bw.DoWork += (o, args) =>
		{
            //now you have a choice: get all images and add when all are retrieved,
            //or get images asynchronously here too...
            //probably best to do the latter:
            string[] fileNames = storage.GetFileNames();
            Parallell.ForEach(fileNames, file =>
            {
                Image image = new Image();
                using(FileStream jpegStream = storage.OpenFile(fileNames[i], FileMode.Open, FileAccess.Read))
                {
                    image.Source = PictureDecoder.DecodeJpeg(jpegStream, 200, 200);
                }
                Dispatcher.BeginInvoke(() => photoList.Items.Add(image));
            }
		};
	bw.RunWorkerAsync();
