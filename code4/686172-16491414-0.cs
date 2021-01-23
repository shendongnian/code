    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Control> list = new List<Control>();
            GetAllControl(PNL_custom, list);
            CenterControlsAsGroup(list, Direction.Both); // center group in the center of the parent
        }
        public enum Direction
        {
            Vertical,
            Horizontal,
            Both
        }
        private void CenterControlsAsGroup(List<Control> controls, Direction direction)
        {
            if (controls.Count > 1)
            {
                int xSum = 0;
                int ySum = 0;
                Point center;
                foreach (Control ctl in controls)
                {
                    center = new Point(ctl.Location.X + ctl.Width / 2, ctl.Location.Y + ctl.Height / 2);
                    xSum = xSum + center.X;
                    ySum = ySum + center.Y;
                }
                Point average = new Point(xSum / controls.Count, ySum / controls.Count);
                center = new Point(controls[0].Parent.Width / 2, controls[0].Parent.Height / 2);
                int xOffset = center.X - average.X;
                int yOffset = center.Y - average.Y;
                foreach (Control ctl in controls)
                {
                    switch (direction)
                    {
                        case Direction.Vertical:
                            ctl.Location = new Point(ctl.Location.X + xOffset, ctl.Location.Y);
                            break;
                        case Direction.Horizontal:
                            ctl.Location = new Point(ctl.Location.X, ctl.Location.Y + yOffset);
                            break;
                        case Direction.Both:
                            ctl.Location = new Point(ctl.Location.X + xOffset, ctl.Location.Y + yOffset);
                            break;
                    }
                }
            }
        }
        private void GetAllControl(Control c, List<Control> list)
        {
            //gets all controls and saves them to a list
            foreach (Control control in c.Controls)
            {
                list.Add(control);
            }
        }
    }
