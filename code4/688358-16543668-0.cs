     Create an instance of a ListView column sorter and assign it 
    // to the ListView control.
    lvwColumnSorter = new ListViewColumnSorter();
    this.listView1.ListViewItemSorter = lvwColumnSorter;
    lvwColumnSorter.SortColumn = Column;
