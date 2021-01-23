    // are you sure want to get all spans? This will get you lots more unrelated ones
    // please try use xpath or css selector to only get the ones related
    IList<IWebElement> spanList = driver.FindElements(By.TagName("span"));
    
    // now you want loop through each of them, check if text == App4 as an example
    foreach (IWebElement span in spanList) {
        if (span.Text == "App4") {
            // click the spane with text App4
            span.Click(); // now sure what you want to click here, please clarify
        }
    }
    
    // version using Linq
    // spanList.First(span => span.Text == "App4").Click();
