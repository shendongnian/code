    HtmlGenericControl s = new HtmlGenericControl("span");
    s.Attributes.Add("class", "myCssClass");
    s.Attributes.Add("id", "myUniqueIdButNotNeeded");
    // then your button as normal
    ImageButton img = new ImageButton();
    // rest of your button code...
    
    // add button to span
    s.Controls.Add(img);
    // add the span
    container.Controls.Add(s);
