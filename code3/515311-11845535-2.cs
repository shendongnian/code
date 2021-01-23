    private void Form1_Load(object sender, EventArgs e)
    {
        AdvRichTextBox tb = new AdvRichTextBox();
    
        tb.SelectionAlignment = TextAlign.CenterJustify;
        tb.SelectedText = "Here is a justified paragraph. It will show up justified using the new AdvRichTextBox control created by who knows.\n";
    
        tb.Width = 250;
        tb.Height = 450;
    
        this.Controls.Add(tb);
    }
