    private IList<int> GetMainIds()
    {
        using (var context = new MyDataContext())
            return context.Main.Select(m => m.Id).ToList();
    }
    private void FixUpSingleRecord(int mainRecordId)
    {
        using (var localContext = new MyDataContext())
        {
            var main = localContext.Main.FirstOrDefault(m => m.Id == mainRecordId);
            if (main == null)
                return;
            foreach (var childOneQuality in main.ChildOneQualities)
            {
                // If child one is not found, create it
                // Create the relationship if needed
            }
            // Repeat for ChildTwo and ChildThree
            localContext.SaveChanges();
        }
    }
    public void FixUpMain()
    {
        var ids = GetMainIds();
        foreach (var id in ids)
        {
            var localId = id; // Avoid closing over an iteration member
            ThreadPool.QueueUserWorkItem(delegate { FixUpSingleRecord(id) });
        }
    }
