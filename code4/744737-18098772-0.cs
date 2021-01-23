    int rowCount = driver.FindElements(By.CssSelector("#table_id tr"));
    for (int i = 0; i < rowCount ; i++)
    {
        var table = driver.FindElement(By.Id("some ID"));
        rows = table.FindElements(By.TagName("tr"));
        // the rest of the code
    }
