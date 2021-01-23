    var id = 1;
    var amount = 5;
    var existing = db.Test.SingleOrDefault(x => x.Id == id);
    if (existing != null)
    {
        existing.Amount = existing.Amount + amount;
    }
    else 
    {
        db.Test.Add(new Test{Id=id,Amount=amount});
    }
    db.SaveChanges();
