    using (var tx = new TransactionScope())
    {
        //session1.Save(obj1);
        //session2.Save(obj2);
        tx.Complete();
    }
