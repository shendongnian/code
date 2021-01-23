    private void Battlefield_Paint(object sender, PaintEventArgs e)
      {
          using (SolidBrush blackBrush = new SolidBrush(Color.Black))
          using (SolidBrush redBrush = new SolidBrush(Color.Red))
          {
              e.Graphics.FillRectangle(blackBrush, new Rectangle(12, 12, 76, 23));
              e.Graphics.FillRectangle(redBrush, new Rectangle(14, 14, (int)(72.0*((double)p1.CurrentHealth/(double)p1.MaxHealth)), 19));
              int result = 72 * (p1.CurrentHealth / p1.MaxHealth);
              Console.WriteLine(result);
          }
      }
