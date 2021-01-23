    private void tbEntry_KeyDown(object sender, KeyEventArgs e)
    {
        Decimal entry;
        if (e.KeyCode == Keys.Enter)
        {
            if (Decimal.TryParse(tbEntry.Text, out entry))
            {
                score.Add(entry);
            }
            tbResult.Text = score.Sum(s => s).ToString();
            tbEntry.Text = string.Empty;
        }
    }
