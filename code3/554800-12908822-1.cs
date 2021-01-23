    using (NoavaranModel.NoavaranEntities1 db=new NoavaranModel.NoavaranEntities1())
            {
                var query = db.Students.Where(p => p.Type == "پیش ثبت نام" && p.Approved == false);
                foreach(var record in query)
                {
                  record.IsRecivedSMS = true;
                }
    
                db.SaveChanges();
    
            }
