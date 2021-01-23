    private void Form1_Click(object sender, EventArgs e)
    {
      var p = PointToClient(Cursor.Position);
      var c = GetChildAtPoint(p);
      if (c != null && c.Enabled == false)
        System.Media.SystemSounds.Beep.Play();
    }
