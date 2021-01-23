    Panel p = pnl;
    p.ID = "b_con";
    //p.Attributes.Add("runat", "server"); -- Not necessary
    this.Controls.Add(p);
    Button b = new Button();
    b.Attributes.Add("value", "reply");
    b.Attributes.Add("id", Convert.ToInt32(r["Message_ID"]).ToString());
    b.Attributes.Add("class", "button");
    b.Click += new System.EventHandler(button_Click);
    p.Controls.Add(b);
