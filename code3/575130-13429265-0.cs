            private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
            {
                    e.DrawFocusRectangle();
                    Bitmap bmp = new Bitmap(e.Bounds.Width, e.Bounds.Height);
                    Graphics g = Graphics.FromImage(bmp);
    
                    if (MeetsCriterion(listBox1.Items[e.Index]))//your method that determines should current item be highlighted 
                    {
                        g.Clear(Color.Red);
                    }
                    else
                    {
                        g.Clear(listView1.BackColor);
                    }
                    g.DrawString(listBox1.Items[e.Index].ToString() , listView1.Font, new SolidBrush(listView1.ForeColor), e.Bounds);
                    e.Graphics.DrawImage(bmp, e.Bounds);
                    g.Dispose();
            }
