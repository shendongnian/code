     public bool ValidateDecimalTextBoxes(TextBox[] textBoxes,PaintEventArgs e)
            {
                foreach (TextBox txt in textBoxes)
                {
                    if (txt isdecimal) // your condition
                    { 
                         System.Drawing.Rectangle rect = new Rectangle(txt.Location.X, txt.Location.Y+2, 
                            txt.ClientSize.Width+4, txt.ClientSize.Height);
                        rect.Inflate(1, 3);
                        System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, rect, Color.Red, ButtonBorderStyle.Solid);
                    }
    
                    return true;
                }
            }
