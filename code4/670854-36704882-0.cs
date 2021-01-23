    //The below code waits 2 times in order for the problem element to go away.
    int attempts = 2;
    var elementsWeWantGone = WebDriver.FindElements(By.Id("id"));
    while (attempts > 0 && elementsWeWantGone.Count > 0)
    {
        Thread.Sleep(500);
        elementsWeWantGone = WebDriver.FindElements(By.Id("id"));
    }
