    public void Filter(List<SampleClass> items)
    {
        List<SampleClass> itemsToRemove = new List<SampleClass>();
        foreach (SampleClass item in items)
        {
            if (item.Items == null || item.Items.Count == 0)
            {
                if (item.Type != SampleType.type3)
                    itemsToRemove.Add(item);
            }
            else
            {
                Filter(item.Items);
            }
        }
        foreach (SampleClass item in itemsToRemove)
        {
            items.Remove(item);
        }
    }
