    var query = from c in SHIFT
            where TimeSpan.Compare(c.SHIFT_TIME.Add(c.SHIFT_DURATION), 
                    new TimeSpan(DateTime.Now.Hour,
                                 DateTime.Now.Minute,
                                 DateTime.Now.Second)).Equals(1)
            select c;
