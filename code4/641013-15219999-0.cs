            var result = db.Mercedes.Where(m => m.Username == User.Identity.Name).OrderByDescending(m=>m.CurrentDate);
            var result2 = db.Mobiles.Where(m => m.UserName == User.Identity.Name).OrderByDescending(m => m.CurrentDate);
 
            var combinelist= result.Concat(result2).ToList();
       
