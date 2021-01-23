       public ActionResult SomeAction( FormCollection form)
        {
         var date = form["date"];
                   if (date != String.Empty)
                    {
                        model.date= DateTime.Parse(dateto);
                    }
           return RedirectToAction("YourNewAction");
        }
