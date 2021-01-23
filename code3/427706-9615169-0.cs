    IList<IWebElement> options = elem.FindElements(By.TagName("option"));
    foreach (IWebElement option in options)
    {
        Console.WriteLine(option.Text);
    }
