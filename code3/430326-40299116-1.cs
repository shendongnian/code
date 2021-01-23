    private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {             
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Rectangle mouseRect = new Rectangle(e.X, e.Y, 1, 1);
                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    if (tabControl1.GetTabRect(i).IntersectsWith(mouseRect))
                    {
                        tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                }     
            }   
        }
