    for ( ... ) {
      g.Clear(Color.White);
  
      // somehow alter cert_id, date_cert, etc...
      g.DrawString(cert_id, new Font("B  Zar", 3,System.Drawing.FontStyle.Bold), Brushes.Black, new Point(85, 95));
      g.DrawString(date_cert, new Font("B  Zar", 3, System.Drawing.FontStyle.Bold), Brushes.Black, new Point(85, 135));
      // etc
