    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    public class GradientContainer : ContainerControl
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(e.ClipRectangle, 
                           Color.Red, Color.Blue, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
        }
    }
    
    class Test
    {
        static void Main()
        {
            var label = new Label { 
                Text = "Label",
                Location = new Point(20, 50)
            };
            var container = new GradientContainer {
                Size = new Size(200, 200),
                Location = new Point(0, 0),
                Controls = { label }
            };        
            
            Form form = new Form {
                Controls = { container },
                Size = new Size(300, 300)
            };
            Application.Run(form);
        } 
    }
