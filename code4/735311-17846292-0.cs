    public ActionResult DeleteSelected(int[] Ids)
    {
       //do something
       MyModel model = new Model(); //create object with new data
       return Partial("_PartialViewName", model);
    }
