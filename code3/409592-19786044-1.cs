      private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
      {
          e.DrawBackground(); 
          if (e.Item.Selected) 
          {
              e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 194, 87)), e.Bounds); 
          } 
          e.Graphics.DrawString(e.Item.Text, new Font("Arial", 10), new SolidBrush(Color.Black), e.Bounds); 
      }
