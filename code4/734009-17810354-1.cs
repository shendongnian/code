      public ActionResult Sample()
        {
            Model1 model = new Model1();
            if (model.SameView)
            {
                // Set it to false and what is ur condition 
            }
            else
            {
                model.SameView = true;
            }
            return View("Sample", model);
        
        }
