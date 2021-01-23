	using iTextSharp.text.pdf;
	using iTextSharp.text.pdf.parser;
	private void pdfButton_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFD = new OpenFileDialog();
		openFD.FileName = "";
		openFD.InitialDirectory = "C:\\";
		openFD.Filter = "All PDF Files|*.PDF";
		openFD.Title = "Browse all PDF files";
		if (openFD.ShowDialog() == DialogResult.OK)
		{
			try
			{
				pdf_filename = Path.GetFileNameWithoutExtension(openFD.Filename);
				richtextBox1.Text = ReadPdf(openFD.FileName);
				textBox1.Text = Path.GetFileName(openFD.Filename);
			}
			catch (Exception error)
			{
				MessageBox.Show(error.ToString());
			}
		}
	}
	
	
	private string ReadPdf(string filename)
	{
		if (!File.Exists(filename)) return string.Empty;
		PdfReader reader = new PdfReader(filename);
		string text = string.Empty;
		for (int page = 1; page <= reader.NumberOfPages; page++)
		{
			text += PdfTextExtractor.GetTextFromPage(reader, page);
		}
		return text;
	}
