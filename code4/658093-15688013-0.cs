    // your initial item or better off you can add a client side validator
    // preventing them from submitting the page with the initial value, also call Page.IsValid on server side to make sure they didn't hacked your client side validation.
    if (ddlSite.SelectedIndex != 0)
    {
       var siteId = 0;
       if (int.TryParse(ddlSite.SelectedValue, out siteId)
       {
          // then here build a helper for adding conditions if siteId is present.
          // try using parameterized queries for avoiding sql injection.
       }
       else
       {
          // call your same helper without siteId and it should be smart enough to
          // return a query without where clause.
       }
    }
