    public void Producer(BlockingCollection<string> ids)
    {
        // assuming this.CompanyRepository exists
        foreach (var id in this.CompanyRepository.GetIds())
        {
            ids.Add(id);
        }
        ids.CompleteAdding(); // nothing left for our workers
    }
    public void Consumer(BlockingCollection<string> ids)
    {
        while (true)
        {
           string id = null;
           try
           {
               id = ids.Take();
           } catch (InvalidOperationException) {
           }
       
           if (id == null) break;
           processLists(id);
        }
    }
