    using (MyContext DbCtx = new MyContext())
    {
        var MyExistingFile = DbCtx.File.Find(1);
        var MyExistingCategory = DbCtx.FileCategory.Find(1);
        MyExistingFile.FileCategory = new List<FileCategory>();
        MyExistingFile.FileCategory.Add(MyExistingCategory);
        DbCtx.SaveChanges(); 
    }
