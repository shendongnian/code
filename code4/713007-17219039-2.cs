    public ActionResult MyMethod()
    {
        ViewModel model = new ViewModel();
        //Get someValue from anywhere.
        string reqValue = someValue.FirstOrDefault(r => r.field_name.Equals("q15_2013Collections[0][]"));
        string queryValue = string.Empty();
        if(queryValues != null)
        {
           queryValue = string.IsNullOrEmpty(reqValue .field_data)
                      ? ""
                      : reqValue .field_data;
        }
        model.QueryValue = queryValue ;               
        return View(model);
    }
