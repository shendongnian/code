	public static void SplitBySize(string filename, long limit)
	{
		PdfDocument input = PdfReader.Open(filename, PdfDocumentOpenMode.Import);
		PdfDocument output = CreateDocument(input);
		string name = Path.GetFileNameWithoutExtension(filename);
		string temp = string.Format("{0} - {1}.pdf", name, 0);
		int j = 1;
		for (int i = 0; i < input.PageCount; i++)
		{
			PdfPage page = input.Pages[i];
			output.AddPage(page);
			output.Save(temp);
			FileInfo info = new FileInfo(temp);
			if (info.Length <= limit)
			{
				string path = string.Format("{0} - {1}.pdf", name, j);
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				File.Move(temp, path);
			}
			else
			{
				if (output.PageCount > 1)
				{
					output = CreateDocument(input);
					++j;
					--i;
				}
				else
				{
					throw new Exception(
						string.Format("Page #{0} is greater than the document size limit of {1} MB (size = {2})",
						i + 1,
						limit / 1E6,
						info.Length));
				}
			}
		}
	}
