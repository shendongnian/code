    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            SaveAsBitmap(panel1,"C:\\path\\to\\your\\outputfile.bmp");
        }
    
        public void SaveAsBitmap(Control control, string fileName)
        {   
            //get the instance of the graphics from the control
            Graphics g = control.CreateGraphics();
            
            //new bitmap object to save the image
            Bitmap bmp = new Bitmap(control.Width, control.Height);
    
            //Drawing control to the bitmap
            control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));
            
            bmp.Save(fileName);
            bmp.Dispose();
            
        }
    }
