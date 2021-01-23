            IList<IWebElement> allElements = driver.FindElements(By.CssSelector("*"));
            foreach (var element in allElements)
            {
                if (element.Text == "My inner text that I am looking for") { element.Click(); }
            }
