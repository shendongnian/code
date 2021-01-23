        var updateValues = new List<UpdateBuilder>();
        if (Named != null) { updateValues.Add(Update.Set("Name", "Name1")); }
        if (Date != null) { updateValues.Add(Update.Set("Date", "18/02/2013")); }
        if (Batch != null) { updateValues.Add(Update.Set("Batch", 43)); }
        IMongoUpdate update = Update.Combine(updateValues);
        coll.Update(query, update);
