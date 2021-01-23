        private void listBox1_DrawItem(object sender, DrawItemEventArgs e) {
            e.DrawBackground();
            if (e.Index >= 0) {
                var box = (ListBox)sender;
                var fore = box.ForeColor;
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) fore = SystemColors.HighlightText;
                TextRenderer.DrawText(e.Graphics, box.Items[e.Index].ToString(),
                    box.Font, e.Bounds, fore);
            }
            e.DrawFocusRectangle();
        }
