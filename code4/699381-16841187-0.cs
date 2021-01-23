    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class MyButton : Button
        {
            private Boolean _pressed = false;
    
            protected override void OnPaint(PaintEventArgs pevent)
            {
                if (_pressed)
                    ControlPaint.DrawButton(pevent.Graphics, pevent.ClipRectangle, ButtonState.Pushed);
                else
                    ControlPaint.DrawButton(pevent.Graphics, pevent.ClipRectangle, ButtonState.Normal);
    
                pevent.Graphics.DrawString("Line 1", new System.Drawing.Font("Arial", 8.5f, System.Drawing.FontStyle.Regular), System.Drawing.Brushes.Black, new System.Drawing.PointF(2.0f, 2.0f));
                pevent.Graphics.DrawString("Line 2", new System.Drawing.Font("Tahoma", 14.0f, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Red, new System.Drawing.PointF(2.0f, 17.0f));
            }
    
            protected override void OnMouseUp(MouseEventArgs mevent)
            {
                _pressed = false;
                base.OnMouseUp(mevent);
            }
    
            protected override void OnMouseDown(MouseEventArgs mevent)
            {
                _pressed = true;
                base.OnMouseDown(mevent);
            }
        }
    }
