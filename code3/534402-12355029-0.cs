    void SaveNewC(C newC)
    {
        using (var context = new MyEntities(connectionString))
        {
            context.A.Attach(newC.A);
            context.B.Attach(newC.B);
            context.C.AddObject(newC);
            context.SaveChanges();
        }
    }
