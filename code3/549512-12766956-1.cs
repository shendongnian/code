    // Fixing naming conventions as I go, to make the code more idiomatic...
    using (DataClassDataContext db = new DataClassDataContext())
    {
        IQueryable<YourDataType> query = db.TableAccounts;
        if (name != "")
        {
            query = query.Where(ta => ta.Name == name);
        }
        // Use query here...
    }
