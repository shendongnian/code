       public ActionResult SomeAction( FormCollection form)
        {
         var date = form["date"];
                   if (date != String.Empty)
                    {
                        MyModel model = new MyModel();
                        model.date= DateTime.Parse(date);
                    }
           return RedirectToAction("YourNewAction", new {date = model.date});
        }
