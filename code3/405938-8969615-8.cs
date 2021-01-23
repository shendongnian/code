    UIElement[] qwe = new UIElement[3]; 
    qwe[0] = new UIElementButton(); 
    qwe[1] = new UIElementLabel(); 
    qwe[2] = new UIElementSomethingElse(); 
    qwe[0].Click(1, 2); // Invokes UIElementButton.Click
    qwe[1].Draw(3, 4);  // Invokes UIElementLabel.Draw
