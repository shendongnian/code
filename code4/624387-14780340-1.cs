    public void Filter(List<SampleClass> items)
    {
        if (items != null)
        {
            List<SampleClass> itemsToRemove = new List<SampleClass>();
            foreach (SampleClass item in items)
            {
                Filter(item.Items);
                if (item.Items == null || item.Items.Count == 0)
                    if (item.Type != SampleType.type3)
                        itemsToRemove.Add(item);
            }
            foreach (SampleClass item in itemsToRemove)
            {
                items.Remove(item);
            }
        }
    }
