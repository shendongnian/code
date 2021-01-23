    public static string GetAllEvents()
    {
        using (CyberDBDataContext db = new CyberDBDataContext())
        {
            return JsonConvert.SerializeObject((from a in db.Events select a).ToList(), new JavaScriptDateTimeConverter());
        }
    }
