    [WebMethod(EnableSession = true)]
    public static Boolean AddRecord(string contextKey)
    {
        List<MID1> MID1s = HttpContext.Current.Session["MID1s"] as List<MID1>;
        using (var ctx = new Entities())
        {
            Boolean RetVal = false;
            MID1s = new List<MID1>();
            MID1 objMID1 = new MID1();
            objMID1.ItemID = 1;
            MID1s.Add(objMID1);
            HttpContext.Current.Session["MID1s"] = MID1s;
            return RetVal;
        }
    }
