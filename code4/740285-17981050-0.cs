    internal void FieldsUpdate(string id, System.Collections.Hashtable fieldsWithChanges, List<string> keysToUpdate)
    {
        using (DBDataContext db = new DBDataContext())
        {
            item myItem = db.items.Single(t=>t.id==id);
            keysToUpdate.ForEach(key => {
    			typeof(item).GetProperty(key)
    				.SetValue(yourInstance, GetValue(fieldsWithChanges, key), null);
            });
            db.SubmitChanges();
        }
    }
