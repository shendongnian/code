    StringBuilder message = new StringBuilder();
    bool error = false;
    
    if (!IsElementPresent(By.XPath("//a/img[@src='/Img1.png']")))
    {
        message.AppendLine("Img1 not present");
        error = true;
    }
    
    if (!IsElementPresent(By.XPath("//a/img[@src='/Img2.png']")))
    {
        message.AppendLine("Img2 not present");
        error = true;
    }
    
    if (!IsElementPresent(By.XPath("//a/img[@src='/Img3.png']")))
    {
        message.AppendLine("Img3 not present");
        error = true;
    }
    
    if Assert.IsFalse(error, message.ToString());
