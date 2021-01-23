    //The answare i was looking for when searching
    public void Answer()
    {
        IEnumerable<YourClass> first = this.GetFirstIEnumerableList();
        //Assign to empty list so we can use later
        IEnumerable<YourClass> second = new List<YourClass>();
        if (IwantToUseSecondList)
        {
            second = this.GetSecondIEnumerableList();  
        }
        IEnumerable<SchemapassgruppData> concatedList = first.Concat(second);
    }
