    ListAdapterType1 adapter1 = new ListAdapterType1();
    ListAdapterType2 adapter2 = new ListAdapterType2();
    ListAdapterType3 adapter3 = new ListAdapterType3();
    
    ListSectionAdapter sectionAdapter = new ListSectionAdapter(this);
    sectionAdapter.AddSection("Section 1", "Column 1", "Column 2", "Column 3", adapter1);
    sectionAdapter.AddSection("Section 2", "Column 1", "Column 2", "Column 3", adapter2);
    sectionAdapter.AddSection("Section 3", "Column 1", "Column 2", "Column 3", adapter3);
    
    ListView myList = FindViewById<ListView>(Resource.Id.MyList);
    myList.SetAdapter(sectionAdapter);
