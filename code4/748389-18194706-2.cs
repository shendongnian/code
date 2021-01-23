    Bitmap bmp = new Bitmap(@"G:\Cert_template.png");
    for ( ... ) {
      Bitmap newBitmap = new Bitmap(bmp);
      using (Graphics g = Graphics.FromImage(newBitmap)) {
  
        // somehow alter cert_id, date_cert, etc...
        g.DrawString(cert_id, new Font("B  Zar", 3,System.Drawing.FontStyle.Bold), Brushes.Black, new Point(85, 95));
        g.DrawString(date_cert, new Font("B  Zar", 3, System.Drawing.FontStyle.Bold), Brushes.Black, new Point(85, 135));
        g.DrawString(s1 + s3, new Font("B  Zar", 4, System.Drawing.FontStyle.Bold), Brushes.Black, new Point(90, 290));
        g.DrawString(s4, new Font("B  Zar", 3, System.Drawing.FontStyle.Bold), Brushes.Black, new Point(480, 360));
        g.DrawString(date_exam, new Font("B  Zar", 3, System.Drawing.FontStyle.Bold), Brushes.Black, new Point(170, 515));
        g.DrawString(Convert.ToString(mark), new Font("B  Zar", 3, System.Drawing.FontStyle.Bold), Brushes.Black, new Point(520, 600));
        g.DrawString(lvl, new Font("B  Zar", 3, System.Drawing.FontStyle.Bold), Brushes.Black, new Point(150, 600));
        g.DrawString(prvnc, new Font("B  Zar", 3, System.Drawing.FontStyle.Bold), Brushes.Black, new Point(170, 780));
        g.DrawString(center, new Font("B  Zar", 3, System.Drawing.FontStyle.Bold), Brushes.Black, new Point(310, 870));
        g.DrawString(inst, new Font("B  Zar", 3, System.Drawing.FontStyle.Bold), Brushes.Black, new Point(150, 870));
        // and here you do something with your newBitmap instance
        // (for example: you save it to another filename)
      }
    }
