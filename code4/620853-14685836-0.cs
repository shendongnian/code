    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult DisplayCustomer(FormCollection frm)
    {
        Info info = new Info();
        info.name = Convert.ToString( Request.Form["name"]);
        info.Price = Convert.ToDouble(Request.Form["price"]);
        info.CustomerId = Convert.ToInt32(Request.Form["customerid"]);
        return View(info);
    }
