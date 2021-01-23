    protected void TextBox1_TextChanged(object sender, EventArgs e)
            {
                var current = TextBox1.Text;
                foreach (ListItem item in ListBox1.Items)
                {
                    if (item.Text.ToLower().Contains(current.ToLower()))
                        item.Selected = true;
                }
            }
