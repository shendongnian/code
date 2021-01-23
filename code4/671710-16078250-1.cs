        public ActionResult Name(int Id, string Name)
        {
            MyModel model = new MyModel 
            {
                Id = Id,
                Name = Name
            };
            
            return View(model);
        }
