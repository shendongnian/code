    using (NoavaranModel.NoavaranEntities1 db=new NoavaranModel.NoavaranEntities1())
            {
                var query = db.Students.Where(p => p.Type == "پیش ثبت نام" && p.Approved == false);
                query.ForEach(r => r.IsRecivedSMS = true);
    
                db.SaveChanges();
    
            }
