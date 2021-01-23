    private void listView1_DrawColumnHeader(object sender,
            DrawListViewColumnHeaderEventArgs e)
        {
                // Draw the header text. 
                using (Font headerFont =
                            new Font("Helvetica", 10, FontStyle.Bold, FontColor.Red))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
            return;
        }
