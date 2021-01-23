    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    public class GradientPanel : Panel {
        public GradientPanel() {
            this.ResizeRedraw = true;
        }
        protected override void OnPaintBackground(PaintEventArgs e) {
            using (var brush = new LinearGradientBrush(this.ClientRectangle, 
                       Color.Black, Color.White, LinearGradientMode.ForwardDiagonal)) {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
