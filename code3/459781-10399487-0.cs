     public void ClickSave(Element element, IWebDriver webDriver)
            {
                if (webDriver.FindElement(By.LinkText(element.Text)).Enabled)
                {
                    element.Click();
                }
            }
