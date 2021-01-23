	private async void UnZipFile(string file)
	{
		var folder = ApplicationData.Current.LocalFolder;
		using (var zipStream = await folder.OpenStreamForReadAsync(file))
		{
			using (MemoryStream zipMemoryStream = new MemoryStream((int)zipStream.Length))
			{
				await zipStream.CopyToAsync(zipMemoryStream);
				using (var archive = new ZipArchive(zipMemoryStream, ZipArchiveMode.Read))
				{
					foreach (ZipArchiveEntry entry in archive.Entries)
					{
					
						if (entry.Name == "")
						{
							// Folder
							await CreateRecursiveFolder(folder, entry);
						}
						else
						{
							// File
							await ExtractFile(folder, entry);
						}
					}
				}
			}
		}
	}
	private async Task CreateRecursiveFolder(StorageFolder folder, ZipArchiveEntry entry)
	{
		var steps = entry.FullName.Split('/').ToList();
		steps.RemoveAt(steps.Count() - 1);
		foreach (var i in steps)
		{
			await folder.CreateFolderAsync(i, CreationCollisionOption.OpenIfExists);
			folder = await folder.GetFolderAsync(i);
		}
	}
	private async Task ExtractFile(StorageFolder folder, ZipArchiveEntry entry)
	{
		var steps = entry.FullName.Split('/').ToList();
		steps.RemoveAt(steps.Count() - 1);
		foreach (var i in steps)
		{
			folder = await folder.GetFolderAsync(i);
		}
		using (Stream fileData = entry.Open())
		{
			StorageFile outputFile = await folder.CreateFileAsync(entry.Name, CreationCollisionOption.ReplaceExisting);
			using (Stream outputFileStream = await outputFile.OpenStreamForWriteAsync())
			{
				await fileData.CopyToAsync(outputFileStream);
				await outputFileStream.FlushAsync();
			}
		}
	}
