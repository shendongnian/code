    //Create the extended property definition.
    ExtendedPropertyDefinition taskCompleteProp = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Task, 0x0000811C, MapiPropertyType.Boolean);
    //Create the search filter.
    SearchFilter.IsEqualTo filter = new SearchFilter.IsEqualTo(taskCompleteProp, false);                    
    //Get the tasks.
    FindItemsResults<Item> tasks = service.FindItems(WellKnownFolderName.Tasks, filter, new ItemView(50));
