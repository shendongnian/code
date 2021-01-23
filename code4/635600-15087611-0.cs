    var Model = (from n in db.TblNews
                         select new News //class name here
                         {
                             ID = n.ID,
                             Title = n.Title,
                             Description = n.Description,
                             Category = n.TblCategory.CategoryName
                         });
            return View(Model.ToList());
