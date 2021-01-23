    Button btn = new Button();
    btn.Name = "Dynamic Button";
    btn.Id = "DynButton"
    btn.Width = 50;
    btn.Click = {...};
    [...]
    panel.Controls.Add(btn); // panel is a parent container control. You have to have a parent for you button.
