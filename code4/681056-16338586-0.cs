    var style = new StyledStringElement("Contact Email",item.Email) {
                BackgroundColor=UIColor.FromRGB(71,165,209),
                TextColor=UIColor.White,
                DetailColor=UIColor.White,
            };
    
    style.Tapped += delegate {
                MFMailComposeViewController email = new MFMailComposeViewController();
                this.NavigationController.PresentViewController(email,true,null);
        };
    
    section.Add(style);
