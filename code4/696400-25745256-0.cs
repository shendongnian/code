      public static bool WaitUntil(this IWebDriver driver, Func<IWebDriver, bool> expression, int timeOutSeconds = 10)
        {
            TimeSpan timeSpent = new TimeSpan();
            bool result = false;
            while (timeSpent.TotalSeconds < timeOutSeconds)
            {
                result = expression.Invoke(driver);
                if (result == true)
                {
                    break;
                }
                Thread.Sleep(timeSleepingSpan);
                timeSpent = timeSpent.Add(new TimeSpan(0, 0, 0, 0, timeWaitingSpan));
            }
            return result;
        }
