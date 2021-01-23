    using(var tran = conn.CreateTransaction())
    {
        valsPending = tran.Hashes.GetAll(db, key);
        tran.Keys.Remove(db, key);
        await tran.Execute();
        var vals = await valsPending;
        // iterate dictionary in "caps", decoding with UTF-8
    }
