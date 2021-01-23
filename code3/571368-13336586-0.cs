	foreach (Images item in ListOfImages)
	{
		using (System.IO.FileStream output = new System.IO.FileStream(Path.Combine(newPath, item.ImageName + item.ImageExtension),
            System.IO.FileMode.Create, System.IO.FileAccess.Write))
		{
			output.Write(item.File, 0, item.File.Length);
			output.Flush();
			output.Close();
		}
	}
