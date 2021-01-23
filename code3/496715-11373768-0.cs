    public string GetTopic(string rk,string lk = null)
    {
        if (lk!=null)
        { //with param logic
        }
        else
        { //without param logic
        }
        return string.Format("{0}.{1}.{2}",
            rk.Substring(0, 2).TrimStart('0'),
            rk.Substring(2, 2).TrimStart('0').PadLeft(1, '0'),
            rk.Substring(4, 2).TrimStart('0').PadLeft(1, '0'));
    }
