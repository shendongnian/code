    public DateTime? DateLesson
    {
        get
        {
            DateTime? dateTime = Session["DateLesson"] as DateTime?;
            if (dateTime.HasValue) // not null
            {
                // use dateTime.Value
            }
        }
        set
        {
            Session["DateLesson"] = value;
        }
    }
