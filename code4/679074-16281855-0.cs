    private void Form1_Load(object sender, EventArgs e)
    {
        List<string> fonts = new List<string>();
        foreach (FontFamily font in System.Drawing.FontFamily.Families)
        {
            fonts.Add(font.Name);
        }
        listboxfont.DataSource = fonts;
    }
    private void btnPreview_Click(object sender, EventArgs e)
    {
        lblsample.Font = new Font(listboxfont.SelectedItem.ToString(), 12);
    }
