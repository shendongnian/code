    //make sure it is in the main document right now
    driver.SwitchTo().DefaultContent();
        
    //find the outer frame, and use switch frame method
    IWebElement containerFrame = driver.FindElement(By.Id("ContentContainer"));
    driver.SwitchTo().Frame(containerFrame);
        
    //then find the nested frame inside
    IWebElement contentFrame = driver.FindElement(By.Id("Content"));
    driver.SwitchTo().Frame(contentFrame);
    //then find the elements you want in the nested frame
    IWebElement foo = driver.FindElement(By.Id("foo"));
