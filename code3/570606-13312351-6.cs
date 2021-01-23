    public partial class Form1 : Form
    {
        SolidBrush color;
        List<Point> pointListe;
        Point _mousePoint;
        public Form1()
        {
            InitializeComponent();
            pointListe = new List<Point>();
            color = new SolidBrush(Color.Black);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            pointListe.Clear();
            pnlCanvas.Invalidate();
        }
        private void pnlCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            pointListe.Add(e.Location);
        }
        private void pnlCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            _mousePoint = e.Location;
            pnlCanvas.Invalidate();
        }
        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (pointListe.Count > 1)
            {
                e.Graphics.DrawLines(new Pen(color), pointListe.ToArray());
            }
            if (pointListe.Any())
            {
                e.Graphics.DrawLine(new Pen(color), pointListe.Last(), _mousePoint);
            }
        }
    }
