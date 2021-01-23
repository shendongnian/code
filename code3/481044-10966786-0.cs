    public class Form1 : Form
    {
        private Panel printPanel = new Panel();
        private Button printButton = new Button();
        private PrintDocument printDocument1 = new PrintDocument();
        public Form1()
        {
            printPanel.Size = this.ClientSize;
            this.Controls.Add(printPanel);
            printButton.Text = "Print Form";
            printButton.Click += new EventHandler(printButton_Click);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPanel.Controls.Add(printButton);
           
        }
        void printButton_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }
        Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics myGraphics = printPanel.CreateGraphics();
            Size s = printPanel.Size; 
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            Point screenLoc = PointToScreen(printPanel.Location); // Get the location of the Panel in Screen Coordinates
            memoryGraphics.CopyFromScreen(screenLoc.X, screenLoc.Y, 0, 0, s);
        }
        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
        public static void Main()
        {
            Application.Run(new Form1());
        }
    }
