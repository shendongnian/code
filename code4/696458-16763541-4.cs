    public bool ValidateDecimalTextBoxes(TextBox[] textBoxes,Form v)
     {
         Graphics g =v.CreateGraphics();
          foreach (TextBox txt in textBoxes)
           {
             System.Drawing.Rectangle rect = new Rectangle(txt.Location.X, txt.Location.Y+2, 
             txt.ClientSize.Width+4, txt.ClientSize.Height);
              rect.Inflate(1, 3);
              System.Windows.Forms.ControlPaint.DrawBorder(g,rect, Color.Red, ButtonBorderStyle.Solid);
           }
        return true;
      }
