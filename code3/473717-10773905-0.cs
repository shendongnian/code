    using System.Drawing.Drawing2D;
    ...
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
                panelPath = new GraphicsPath();
                panelPath.AddCurve(new Point[] { new Point(470, 470), new Point(430, 440), new Point(400, 480), new Point(470, 560), });
                panelPath.AddCurve(new Point[] { new Point(470, 470), new Point(510, 440), new Point(540, 480), new Point(470, 560), });
                panel1.Paint += new PaintEventHandler(panel1_Paint);
            }
    
            void panel1_Paint(object sender, PaintEventArgs e) {
                e.Graphics.TranslateTransform(-360, -400);
                e.Graphics.FillPath(Brushes.Green, panelPath);
                e.Graphics.DrawPath(Pens.Red, panelPath);
            }
            GraphicsPath panelPath;
        }
