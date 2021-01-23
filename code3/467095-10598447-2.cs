    List<Button> buttons = new List<Button>();
    
    foreach (var bt in panel1.Controls)
    {
        if (bt is Button)
        {
            buttons.Add((Button)bt);
        }
    
    }
    
    var lst = buttons.OrderBy(x => x.PointToScreen(Point.Empty).Y).ThenBy(x => x.PointToScreen(Point.Empty).X);
                
    int btext = 1;
    foreach (var button in lst)
    {
    
        button.Text = btext.ToString();
        button.BackColor = Color.White;
        btext++;
    }
