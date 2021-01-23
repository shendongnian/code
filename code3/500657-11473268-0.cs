    void panel1_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        foreach (DataRow dr in dt.Rows) {
          Point p = new Point(Convert.ToInt32(dr["XCord"]), Convert.ToInt32(dr["YCord"]));
          Size s = TextRenderer.MeasureText(dr["ID"].ToString(), panel1.Font);
          if (new Rectangle(p, s).Contains(e.Location)) {
            MessageBox.Show("Clicked on " + dr["ID"].ToString());
          }
        }
      }
    }
