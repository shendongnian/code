    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        PrintDocument printDocument = new PrintDocument();
        public Form1()
        {
            InitializeComponent();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
        }
        void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(printData.Width, printData.Height);
            printData.DrawToBitmap(bitmap, new System.Drawing.Rectangle(new Point(0, 0), printData.Size));
            e.Graphics.DrawImage(bitmap, e.MarginBounds.Location);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pd.Print();
        }
    }
    }
