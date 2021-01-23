    public int GetCountOfElementsByClassName(string className)
    {
        for (int second = 0; second <= 10; second++)
        {
            try
            {
                // bit that needs to vary
                matchedElements = driver.FindElements(By.ClassName(className));
                if (matchedElements.Count > 0)
                {
                    break;
                }
            }
            catch (Exception)
            {
            }
            Thread.Sleep(1000);
        }          
        return matchedElements.Count;
    }
