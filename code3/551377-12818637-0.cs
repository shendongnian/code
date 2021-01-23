    @using(Html.BeginForm("TryMeOut")){
       @Html.Hidden("returnUrl",Request.PathAndQuery);
       <input type="submit" value="Try me out">
    }
    
    public ActionResult TryMeOut(string returnUrl)
    {
    //return the user.
    }
