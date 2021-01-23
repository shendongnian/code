     while (true)
            {
                try
                {   
                    IWebElement element = driver.FindElement(By.Id(...));
                    if (element.Displayed)
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
    
