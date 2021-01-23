    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsExamples
    {
        public partial class DragCircle : Form
        {
            private bool bDrawCircle;
            private int circleX;
            private int circleY;
            private int circleR = 50;
            public DragCircle()
            {
                InitializeComponent();
            }
            private void InvalidateCircleRect()
            {
                this.Invalidate(new Rectangle(circleX, circleY, circleR + 1, circleR + 1));
            }
            private void DragCircle_MouseDown(object sender, MouseEventArgs e)
            {
                circleX = e.X;
                circleY = e.Y;
                bDrawCircle = true;
                this.Capture = true;
                this.InvalidateCircleRect();
            }
            private void DragCircle_MouseUp(object sender, MouseEventArgs e)
            {
                bDrawCircle = false;
                this.Capture = false;
                this.InvalidateCircleRect();
            }
            private void DragCircle_MouseMove(object sender, MouseEventArgs e)
            {
                if (bDrawCircle)
                {
                    this.InvalidateCircleRect(); //Invalidate region that was occupied by circle before move
                    circleX = e.X;
                    circleY = e.Y;
                    this.InvalidateCircleRect(); //Add to invalidate region the rectangle that circle will occupy after move.
                }
            }
            private void DragCircle_Paint(object sender, PaintEventArgs e)
            {
                if (bDrawCircle)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Red), circleX, circleY, circleR, circleR);
                }
            }
        }
    }
