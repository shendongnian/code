    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
    public class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
        this.DrawMode = DrawMode.OwnerDrawVariable;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            //I removed you int startX... endy... stuff, unless you want to keep it for readability there is no need
            Point p1 = new Point(e.Bounds.Left + 5, e.Bounds.Y + 5);
            Point p2 = new Point(e.Bounds.Right - 5, e.Bounds.Y + 5);
            
            //I am not sure why you would want to call the base.OnDrawItem, feel free to uncomment it if you wish though
            //base.OnDrawItem(e);
            switch (e.Index)
            {
                case 0:
                    using ( Pen SolidmyPen = new Pen(e.ForeColor, 1))
                    e.Graphics.DrawLine(SolidmyPen, p1, p2);
                    break;
                case 1:
                    using (Pen DashedPen = new Pen(e.ForeColor, 1))
                    {
                        DashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawLine(DashedPen, p1, p2);
                    }
                    break;
                case 2:
                    using (Pen DashDot = new Pen(e.ForeColor, 1))
                    {
                        DashDot.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        e.Graphics.DrawLine(DashDot, p1, p2);
                    }
                    break;
            }
        }
    }
