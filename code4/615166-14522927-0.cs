    ...
    public ActionResult Save(FormCollection collection)
            {
                SomethingBase model = null;
                if (collection.AllKeys.Contains("SpecificOne"))
                {
                    model = new ChildOne();
                    TryUpdateModel<ChildOne>((ChildOne)model, collection);
                }
                else
                {
                    model = new ChildTwo();
                    TryUpdateModel<ChildTwo>((ChildTwo)model, collection);
                }
    ...
