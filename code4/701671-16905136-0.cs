    if (TempData.ContainsKey(Alerts.ERROR))
    {
        string temp = TempData[Alerts.ERROR].ToString();
        TempData[Alerts.ERROR] = string.Concat(temp, c.ErrorMessage);
    }
    else
    {
        TempData.Add(Alerts.ERROR, c.ErrorMessage);
    }
