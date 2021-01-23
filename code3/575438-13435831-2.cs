    using(var tran = conn.CreateTransaction())
    {
        valsPending = tran.Hashes.GetAll(db, key);
        tran.Keys.Remove(db, key);
        await tran.Execute();
        var vals = await valsPending;
        // iterate dictionary in "vals", decoding each .Value with UTF-8
    }
