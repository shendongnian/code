    public static void UploadFileToMediaArchive(HttpPostedFile file, string mediaFolderPath)
		{
			try
			{
				WorkflowMediaFile mediaFile = new WorkflowMediaFile();
				mediaFile.FileName = file.FileName;
				mediaFile.FolderPath = mediaFolderPath;
				mediaFile.Title = "";
				mediaFile.Description = "";
				mediaFile.Culture = Thread.CurrentThread.CurrentCulture.Name;
				mediaFile.Length = file.ContentLength;
				mediaFile.MimeType = MimeTypeInfo.GetCanonical(file.ContentType);
				if (mediaFile.MimeType == MimeTypeInfo.Default)
				{
					mediaFile.MimeType = MimeTypeInfo.GetCanonicalFromExtension(System.IO.Path.GetExtension(mediaFile.FileName));
				}
				using (System.IO.Stream readStream = file.InputStream)
				{
					using (System.IO.Stream writeStream = mediaFile.GetNewWriteStream())
					{
						readStream.CopyTo(writeStream);
					}
				}
				IMediaFile addedFile = DataFacade.AddNew<IMediaFile>(mediaFile);
			}
			catch (Exception ex)
			{
				Composite.Core.Log.LogError("UploadFileToMediaArchive", ex.Message);
			}
		}
