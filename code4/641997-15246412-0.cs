    void lb_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            lb.Visible = false;
            lb.Items.Clear();
        }
        if (e.KeyCode == Keys.Enter)
        {
            string line = lb.Text;
            ParseLine(line);
            //Parse();
            string comment = line.Substring(index, line.Length - index);
            rtb.SelectionColor = Color.Green;
            rtb.SelectionFont = new Font("Courier New", 10, FontStyle.Italic);
            rtb.SelectedText = comment + " " + lb.SelectedIndex.ToString();
        }
    }
