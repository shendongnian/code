    if (registeredAndActive)
    {
        // Active Condition. The DEFAULT in SWITCH() will take care of displaying content.
    }
    else
    {
        // !Active Condition.  Shows an alternative version of the default page where the user is told they do not have acces.
        if (MultiView1.ActiveViewIndex != 2) { // check if the page has already been redirected
          Response.Redirect("default.aspx?Error_ID=2");
        }
    }
