    messages = XDocument.Load(MapPath("~/_xml/messages.xml"));
    myMessages.DataSource = 
        messages.Elements("messages")
        .Elements("contact")
        .OrderByDescending(m => DateTime.Parse(m.Element("date").Value))
    myMessages.DataBind();
