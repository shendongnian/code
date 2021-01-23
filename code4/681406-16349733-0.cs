    private void backToolStripMenuItem_Click(object sender, EventArgs e)
    {
        WebBrowser wbControl =
           frontierTabInner.SelectedTab.Controls.OfType<WebBrowser>().FirstOrDefault();
        wbControl.GoBack();
        textBox1.Text = wbControl.Url.ToString();
    }
