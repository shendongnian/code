        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (e.Index >= 0)
            {
                if (IsItemDisabled(e.Index))
                {
                    e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                    e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, Brushes.LightSlateGray, e.Bounds);
                }
                else
                {
                    e.DrawBackground();
                    // Set the brush according to whether the item is selected or not
                    Brush br = ( (e.State & DrawItemState.Selected) > 0) ? SystemBrushes.HighlightText : SystemBrushes.ControlText;
                    e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, br, e.Bounds);
                    e.DrawFocusRectangle();
                }
            }
        }
