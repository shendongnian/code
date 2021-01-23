    List<IEditableContent> lEditableContent = new List<IEditableContent>();
    foreach(var c in db.Contents)
    {
        switch (c.EditorView)
        {
        case "SomeType":
            lEditableContent.Add(new SomeTypeEditableContent(c));
            break;
        default:
            lEditableContent.Add(new DefaultEditableContent(c));
            break;
        }
    }
