    string[] keywords = Environment.GetCommandLineArgs(); 
    Dictionary<string, TextBox> boxes = new Dictionary<string, TextBox>();
    int placement = 10; 
    foreach (string keyword in keywords) 
    { 
        if (keyword == keywords[0]) 
            continue; 
        Label lbl = new Label(); 
        lbl.Text = keyword; 
        lbl.Top = placement; 
        this.Controls.Add(lbl); 
        TextBox txt = new TextBox(); 
        txt.Top = placement; 
        txt.Left = 100; 
        this.Controls.Add(txt); 
        placement += 20; 
        boxes.Add(keyword, txt);
    } 
