    public static void PdfToJpg(string input, string output)
      {
          PdfToImage.PDFConvert pp = new PDFConvert();
          pp.OutputFormat = "jpeg"; //format
          pp.JPEGQuality = 100; //100% quality
          pp.ResolutionX = 300; //dpi
          pp.ResolutionY = 300;
          pp.FirstPageToConvert = 1; //pages you want
          pp.LastPageToConvert = 1;
          pp.Convert(input ,  output ); 
      }
    namespace PdfToJpeg
    {
     {
        PDFConvert converter = new PDFConvert();
        public Form1()
        {
            InitializeComponent();
        }
         try
         {
	PdfToJpg("c:\abc.pdf","c:\" + "output.jpg");
	MessageBox.Show("Files Converted");
         }
         catch (Exception ex)
         {
	MessageBox.Show("Exception Error Occured... " + ex.Message.ToString());
         }
      }
     }
