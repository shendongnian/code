    [Test]
    public void All_images_are_present()
    {
        string message = string.Empty;
    
        message = AssertImage("Img1");
        message += AssertImage("Img2");
        message += AssertImage("Img3");
        ... etc ...
        
        Assert.That(message, Is.Empty, message);
    }
    
    private static string AssertImage(string imageName)
    {
        string imagePath = string.Format(@"//a/img[@src='/{0}.png']", imageName);
    
        if (IsElementPresent(By.XPath("//a/img[@src='/Img1.png']")))
            return string.Empty;
    
        return string.Format("{0} not present;");    
    }
