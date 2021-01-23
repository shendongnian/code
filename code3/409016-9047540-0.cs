    if (strResponse == "VERIFIED")
    {
        // Now All informations are on
        HttpContext.Current.Request.Form;
        // for example you get the invoice like this
        HttpContext.Current.Request.Form["invoice"] 
        // or the payment_status like
        HttpContext.Current.Request.Form["payment_status"] 
    }
    else
    {
      //log for manual investigation
    }
