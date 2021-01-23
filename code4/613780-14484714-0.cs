    [AllowAnonymous]
    public ActionResult _ProgOn()
    {
        string t =  dt.ToString("HH:mm");
        int i = (int)DateTime.Now.DayOfWeek;
        DateTime dt = DateTime.Now;
        var onNow = db.Programs
         .Where(u => u.PrOk == true)
         .Where(u => u.DaId == i)
         .Where(u => u.TimeOn == t); 
        return PartialView(onNow);
