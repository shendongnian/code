           var authors = (from a in db.Authors select a).ToList();
           var jsonData = new {
            total = 5, 
            page=1,
            records = db.Authors.Count(),
            rows = authors.Select(a => new 
                        {
                            id = a.AuthorID,
                            cell = new[] { a.AuthorID.ToString(), a.FirstName, a.LastName }
                        }
            )              
           };
          return Json(jsonData,JsonRequestBehavior.AllowGet);            
        }
