    private Element Generate(Thing x)
    {
        var root = new RootElement(x.Title);
        var section  = new Section(x.Title);
        root.Add(section);
        if (x.Phone != null)
            section.Add(new StyledStringElement("Contact Number",x.Phone) {
                         BackgroundColor=UIColor.FromRGB(71,165,209),
                         TextColor=UIColor.White,
                         DetailColor=UIColor.White,
                     });
        return root;
    }
