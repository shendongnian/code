    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hitTestInfo = listView1.HitTest(e.X, e.Y);
            if (hitTestInfo.Item != null)
            {
                var loc = e.Location;
                loc.Offset(listView1.Location);
    
                // Adjust context menu (or it's contents) based on hitTestInfo details
                this.contextMenuStrip2.Show(this, loc);
            }
        }
    }
