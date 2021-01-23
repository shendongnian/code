            e.DrawBackground(); 
             if (e.Item.Selected) 
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 194, 87)), e.Bounds); 
            } 
            e.Graphics.DrawString(e.Item.Text, new Font("Arial", 10), new SolidBrush(Color.Black), e.Bounds); 
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int ix = 0; ix < listView1.Items.Count; ++ix)
            {
                var item = listView1.Items[ix];
                item.BackColor = (ix % 2 == 0) ? Color.Gray : Color.LightGray;
            }
            
        }
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }
        }
    }
