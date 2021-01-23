    public class PdfReaderExtended : PdfReader
	{
		public PdfReaderExtended(string filename) : base(filename)
		{
		}
		public static PdfReaderExtended CreateInstance(string filename)
		{
			var name = Path.GetFileName(filename);
			try
			{
				return new PdfReaderExtended(filename);
			}
			catch (Exception ex)
			{
				throw new ClientException("Oops");
			}
		}
	}
