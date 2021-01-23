    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        public Form1()
        {
            ClientSize = new Size(400, 200);
            Controls.Add(new LineLabel { Text = "Edit signature", Location = new Point(10, 10), Anchor = AnchorStyles.Left | AnchorStyles.Right, Width = 380 });
        }
    }
    
    public class LineLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
    
            SizeF textSize = e.Graphics.MeasureString(this.Text, this.Font);
            int leftWidth = (int)(textSize.Width + 2);
            Rectangle bounds = new Rectangle(leftWidth, Height / 2 - 4, Bounds.Width - leftWidth, 2);
            ControlPaint.DrawBorder(e.Graphics, bounds, Color.DarkGray, ButtonBorderStyle.Solid);
        }
    }
