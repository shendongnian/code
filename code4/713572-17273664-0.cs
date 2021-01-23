    void tableLayoutPanel1_Resize(object sender, EventArgs e)
            {
                float fWidth = tableLayoutPanel1.GetColumnWidths()[1];
                foreach (Control ctr in tableLayoutPanel1.Controls)
                {
                    if (ctr is Label && ctr.Name.Contains("vName_"))
                    {
                        // -7 for margins
                        Size s = TextRenderer.MeasureText(ctr.Text, ctr.Font, new Size((int)fWidth - 7,1000),
                            TextFormatFlags.VerticalCenter 
                            | TextFormatFlags.Left 
                            | TextFormatFlags.NoPadding 
                            | TextFormatFlags.WordBreak);
                        if(!ctr.MaximumSize.Equals(s))
                            ctr.MaximumSize = new Size(s.Width, s.Height);
                    }
                }
            }
