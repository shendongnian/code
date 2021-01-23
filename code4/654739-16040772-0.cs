    public virtual ActionResult Create(string attkey)
    {
         if (string.IsNullOrEmpty(attkey))
         {
             attkey = generatNewNameForSession('key'); // for examle: kye_jhtyujbvkjadsgfvn
             Response.Redirect("myControle/Create, attkey="+attkey), true);
            }
            ViewBag.AttachmentsKey = attkey;
            if (Session[attkey] == null)
                KeepData(attkey, "");
            .
            .
            .
