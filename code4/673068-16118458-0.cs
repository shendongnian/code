    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
            {
                if (listBox1.Items.Count > 0)
                {
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                    else
                        e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
    
                    string text = listBox1.Items[e.Index].ToString();
    
                    e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top);                
                }
            }
