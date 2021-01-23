        if (registeredAndActive)
        {
            // Active Condition. The DEFAULT in SWITCH() will take care of displaying content.
        }
        else
        {
            // !Active Condition.  Shows an alternative version of the default page where the user is told they do not have acces.
            Response.Redirect("default.aspx?Error_ID=2");
        }
