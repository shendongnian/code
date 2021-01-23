    ContactEntry cEntry = null;
        if(Session["ContactID"] != null)
        {
            if(!String.IsNullOrEmpty(Session["ContactID"]))
            {
            cEntry = new ContactEntry(Convert.ToInt32(Session["ContactID"].ToString());
            }
        }
