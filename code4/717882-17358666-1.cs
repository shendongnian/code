    public ActionResult_Create<T>(T content, Func<YourEntityContainerType, Collection<T>> collectionSelector, YourEntityContainerType db) where T:ISomething, new
    {
        if(ModelState.IsValid)
        {
            T Home = new T();
            Mapper.Map(content, Home);
            if(content.Id <= 0)
                collectionSelector(db).Add(Home);
            else
                db.Entry(Home).State = EntityState.Modified;
            db.SaveChanges();
            return Content("Ok");
        }
        return PartialView(content);
    }
