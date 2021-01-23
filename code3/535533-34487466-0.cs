       private void tbxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                trvMenu.BeginUpdate();
                if (tbxSearch.Text.Length > 0)
                {
                    for (int i = trvMenu.Nodes.Count;  i > 0  ; i--)
                    {
                        NodeFiltering(trvMenu.Nodes[i - 1], tbxSearch.Text);
                    }
                }
                trvMenu.EndUpdate();
            }
