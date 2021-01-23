    TextBox txt = new TextBox();
    txt.ID = "SomeID";
    Form.Controls.Add(txt);
    Button btn = new Button();
    btn.ID = "someID";
    btn.OnClientClick = "foo(" + txt.ClientID + ")";
