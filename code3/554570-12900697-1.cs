    private void ProcessListOfItems(List<string> items)
    { 
        while (items.Count > 0)
        {
            var task = Process3rdParty(thirdPartyLibObject.Process(items[0]);
            if (task.Result)
                items.Remove(0);
        }
    }
