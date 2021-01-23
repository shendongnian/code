	using System;
	using System.IO;
	using System.Linq;
	using System.Text;
	using iTextSharp.text.pdf;
	using iTextSharp.text.pdf.parser;
	namespace Pdf2Text
	{
		class Program
		{
			static void Main(string[] args)
			{
				if (!args.Any()) return;
				
				var file = args[0];
				var output = Path.ChangeExtension(file, ".txt");
				if (!File.Exists(file)) return;
				var bytes = File.ReadAllBytes(file);
				File.WriteAllText(output, ConvertToText(bytes), Encoding.UTF8);
			}
			private static string ConvertToText(byte[] bytes)
			{
				var sb = new StringBuilder();
				try
				{
					var reader = new PdfReader(bytes);
					var numberOfPages = reader.NumberOfPages;
					for (var currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
					{
						sb.Append(PdfTextExtractor.GetTextFromPage(reader, currentPageIndex));
					}
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.Message);
				}
				return sb.ToString();
			}
		}
	}
