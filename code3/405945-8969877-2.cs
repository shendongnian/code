    List<IUIElement> qwe = new List<IUIElement>();
    qwe.Add(new UIElementButton());
    qwe.Add(new UIElementLabel());
    qwe.Add(new UIElementSomethingElse());
    // some sample usages
    foreach(IUIElement element in qwe)
    {
       element.Click();
    }
    qwe[0].Click() //invokes UIElementButton.Click();
    //gets all pointed elements
    var pointedElements = qwe.Where(e => e.IsPointed(x,y));
