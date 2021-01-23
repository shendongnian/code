    public class MyTooltip : Form
    {
        public MyTooltip(int x, int y, int width, int height, string message)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.Width = width;
            this.Height = height;
            this.BackColor = Color.LightYellow;
            Label label = new Label();
            label.Text = message;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label.Dock = DockStyle.Fill;
            this.Padding = new Padding(5);
            this.Controls.Add(label);
        }
    }
