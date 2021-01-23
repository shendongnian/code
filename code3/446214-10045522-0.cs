    public bool IsCurrentPage()
    {
        try
        {
            driver.FindElement(By.LinkText("Logout"));
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }
