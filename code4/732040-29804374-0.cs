    public void SelectDropDownOption(string dropDownID, string option)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (driver.FindElement(By.CssSelector("div[ID^=s2id_" + dropDownID + "]>a.select2-choice")).Displayed) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.CssSelector("div[ID^=s2id_" + dropDownID + "]>a.select2-choice")).Click();
            Thread.Sleep(1000);
            if (driver.FindElement(By.CssSelector("input.select2-input.select2-focused")).Displayed == true)
            {
                driver.FindElement(By.CssSelector("input.select2-input.select2-focused")).SendKeys(option);
                Thread.Sleep(500);
                driver.FindElement(By.CssSelector("input.select2-input.select2-focused")).SendKeys(Keys.Enter);
                Thread.Sleep(500);
            }
            else
            {
                driver.FindElement(By.CssSelector("input.select2-focusser.select2-offscreen")).SendKeys(option);
                Thread.Sleep(500);
                driver.FindElement(By.CssSelector("input.select2-focusser.select2-offscreen")).SendKeys(Keys.Enter);
                Thread.Sleep(500);
            }
           
        }
