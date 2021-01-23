    TestProcess testprocess = dbcontext.TestProcesses.Attach(new TestProcess { MyID = id });
    tp.UpdateID = updateID;
    dbcontext.Entry<TestProcess>(testprocess).Property(tp => tp.UpdateID).IsModified = true;
    dbcontext.Configuration.ValidateOnSaveEnabled = false;
    dbcontext.SaveChanges();
