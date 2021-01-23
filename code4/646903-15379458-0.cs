    string[] lines = { DateTime.Now.Date.ToShortDateString(), DateTime.Now.TimeOfDay.ToString(), message, type, module };
    
    using(StreamWriter streamWriter = new StreamWriter(HttpContext.Current.Server.MapPath("~/logger.txt"), true))
    {
        streamWriter.WriteLine(lines);
    }
