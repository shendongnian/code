    string[] textToAddList = File.ReadAllLines(@"C:\Users\Syd\Desktop\list.txt");
    browser.GoTo("https://site.com");
    
    foreach (string textToAdd in textToAddList)
    {
        browser.TextField(Find.ByName("form")).TypeText(textToAdd);
        browser.Button(Find.ByName("submit")).Click();
        browser.WaitUntilComplete();
        if (!browser.ContainsText("text to find"))
        {
            //Log here
            break;
        }
    }
