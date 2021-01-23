    if (logOutLink.Exists() && ExpectedConditions.ElementToBeClickable(logOutLink).Equals(true))
                {
                    logOutLink.Click();
                }
                else
                {
                    Browser.Goto("/");
                }
