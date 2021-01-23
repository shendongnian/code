    for (int i = 0; i < lineCount; i++)
    {
        TextBlock txtb = new TextBlock();
        scrlPanel.RowDefinitions.Add(new RowDefinition());
        txtb.Name = "txtb" + i;
        txtb.Text = obj.ReadLine();
        txtb.Height = 60;
        txtb.Width = 110;
        txtb.HorizontalAlignment = HorizontalAlignment.Left;
        txtb.TextAlignment = TextAlignment.Justify;
        txtb.TextWrapping = TextWrapping.Wrap;
        txtb.ToolTip = txtb.Text;
        scrlPanel.Children.Add(txtb);
        Grid.SetRow(txtb, i);
    }
    for (int i = 0; i < lineCount; i++)
    {
        RichTextBox rtb = new RichTextBox();
        Paragraph p = rtb.Document.Blocks.FirstBlock as Paragraph;
        rtb.Name = "rtb" + i;
        rtb.Height = 60;
        rtb.Width = 220;
                                
        p.LineHeight = 1;
        rtb.HorizontalAlignment = HorizontalAlignment.Right;
        scrlPanel.Children.Add(rtb);
        Grid.SetRow(rtb, i);
    }
