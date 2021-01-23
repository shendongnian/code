    popupContainer = new PopupContainer();       
    popupContainer.Content =   PopupContent;       
    PopupContent.Visibility = Visibility.Visible;       
    rootContent.Children.Add(popupContainer);  
    NameScope.SetNameScope(popupContainer, NameScope.GetNameScope(this)); //Or
    // NameScope.SetNameScope(popupContainer, NameScope.GetNameScope(rootContent)); 
