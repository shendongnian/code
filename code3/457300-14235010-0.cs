    void GeneratePdfFromHtml()
    {
      const string outputFilename = @".\Files\report.pdf";
      const string inputFilename = @".\Files\report.html";
    
      using (var input = new FileStream(inputFilename, FileMode.Open))
      using (var output = new FileStream(outputFilename, FileMode.Create))
      {
    	CreatePdf(input, output);
      }
    }
    
    void CreatePdf(Stream htmlInput, Stream pdfOutput)
    {
      using (var document = new Document(PageSize.A4, 30, 30, 30, 30))
      {
    	var writer = PdfWriter.GetInstance(document, pdfOutput);
    	var worker = XMLWorkerHelper.GetInstance();
    
    	document.Open();
    	worker.ParseXHtml(writer, document, htmlInput, null, Encoding.UTF8, new UnicodeFontFactory());
    
    	document.Close();
      }    
    }
    public class UnicodeFontFactory : FontFactoryImp
    {
    	private static readonly string FontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
    	  "arialuni.ttf");
    
    	private readonly BaseFont _baseFont;
    
    	public UnicodeFontFactory()
    	{
    	  _baseFont = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
    	  
    	}
    
    	public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color,
    	  bool cached)
    	{
    	  return new Font(_baseFont, size, style, color);
    	}
    }
