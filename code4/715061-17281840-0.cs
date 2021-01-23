    public ActionResult Index(int id)
            {
                try
                {
                var cnty = from r in db.Clients
                           where r.ClientID == id
                           select r;
    
                if (cnty != null) // breakpoint here
                {
                    return View(cnty); // F11 jumps over this section of code returning me to the error page below.
                }
                return HttpNotFound();
                }
                catch (Exception ex)
                { 
                      //report error
                }
            }
