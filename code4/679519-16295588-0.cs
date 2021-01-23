    public partial class Form1 : Form
        {
            public event PaintEventHandler Paint;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
                this.Controls.Add(pictureBox1);
            }
    
            private void pictureBox_Paint(object sender, PaintEventArgs e)
            {
                QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.M);
                QrCode qrCode;
                encoder.TryEncode("www.abix.dk", out qrCode);
    
                new GraphicsRenderer(
                    new FixedCodeSize(200, QuietZoneModules.Two)).Draw(e.Graphics, qrCode.Matrix);
            }
        }
