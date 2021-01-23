    using OpenQA.Selenium.Interactions;
		 public void CopyPaste(string copy)
        {
            Clipboard.SetText(copy);
            new Actions(driver).SendKeys(OpenQA.Selenium.Keys.LeftShift + OpenQA.Selenium.Keys.Insert).Perform();
    //because it switch to uppercase we do one more click
            new Actions(driver).SendKeys(OpenQA.Selenium.Keys.LeftShift).Perform();
        }
    texarea.Click;
    // if driver refuse to click textarea you can force it with:
    //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='MyTextareaId']")));
    // not proven, but I think textarea.SendKeys(""); Will click inside the textarea
    //Call the method
    CopyPaste("Text Appear In the Textarea");
