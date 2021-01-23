    public partial class MyPrintPreviewForm : Form
    {
       public MyPrintPreviewForm()
       {
           InitializeComponent();
       }
          
       public XtraReport report
       {
          set { printControl1.PrintingSystem = value.PrintingSystem; }
       }
    }
