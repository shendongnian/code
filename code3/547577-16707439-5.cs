    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class Form1: Form
    {
        private Grid World { get; set; }
        public Form1 ()
        {
            this.InitializeComponent();
            this.World = new Grid(new Size(50, 50));
            this.World.SetDimensions(new Rectangle(0, 0, this.pictureBox1.ClientSize.Width, this.pictureBox1.ClientSize.Height));
        }
        private void Form1_Shown (object sender, EventArgs e)
        {
            this.pictureBox1.Invalidate();
        }
        private void Form1_Resize (object sender, EventArgs e)
        {
            this.World.SetDimensions(new Rectangle(0, 0, this.pictureBox1.ClientSize.Width, this.pictureBox1.ClientSize.Height));
            this.pictureBox1.Invalidate();
        }
        private void pictureBox1_MouseMove (object sender, MouseEventArgs e)
        {
            for (int r=0; r < this.World.Size.Height; r++)
            {
                for (int c=0; c < this.World.Size.Width; c++)
                {
                    this.World.Cells [c, r].Hover = this.World.Cells [c, r].Bounds.Contains(e.X, e.Y);
                }
            }
            this.pictureBox1.Invalidate();
        }
        private void pictureBox1_MouseClick (object sender, MouseEventArgs e)
        {
            for (int r=0; r < this.World.Size.Height; r++)
            {
                for (int c=0; c < this.World.Size.Width; c++)
                {
                    if (this.World.Cells [c, r].Bounds.Contains(e.X, e.Y))
                    {
                        this.World.Cells [c, r].RotateState();
                    }
                }
            }
        }
        private void pictureBox1_Paint (object sender, PaintEventArgs e)
        {
            for (int r=0; r < this.World.Size.Height; r++)
            {
                for (int c=0; c < this.World.Size.Width; c++)
                {
                    if (this.World.Cells [c, r].State == Cell.CellState.Active)
                    {
                        e.Graphics.FillRectangle(System.Drawing.Brushes.Blue, this.World.Cells [c, r].Bounds);
                    }
                    else if (this.World.Cells [c, r].State == Cell.CellState.Inactive)
                    {
                        e.Graphics.FillRectangle(System.Drawing.Brushes.White, this.World.Cells [c, r].Bounds);
                    }
                    else if (this.World.Cells [c, r].State == Cell.CellState.Intermediate)
                    {
                        e.Graphics.FillRectangle(System.Drawing.Brushes.Gray, this.World.Cells [c, r].Bounds);
                    }
                    if (this.World.Cells [c, r].Hover)
                    {
                        e.Graphics.DrawRectangle(System.Drawing.Pens.Red, this.World.Cells [c, r].Bounds);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(System.Drawing.Pens.Black, this.World.Cells [c, r].Bounds);
                    }
                }
            }
        }
    }
