    var root = new RootElement ("Student Guide") {
        new Section("Contacts"){
            from x in AppDelegate.getControl.splitCategories("Contacts")
            let hasPhone = x.Phone == null
            select hasPhone 
             ? (Element)new RootElement(x.Title) {
                 new Section(x.Title){
                     (Element)new StyledStringElement("Contact Number",x.Phone) {
                         BackgroundColor=UIColor.FromRGB(71,165,209),
                         TextColor=UIColor.White,
                         DetailColor=UIColor.White,
                     },
                 }
             }
             : (Element)new RootElement(x.Title)
        },
    };
