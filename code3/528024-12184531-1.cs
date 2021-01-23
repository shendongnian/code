    IEnumerable<MyType> GetCurrentPage()
    {
        return orderedEnumerator.Take(pageSize);
    }
    
    public void nextPageButton_Click(object sender, EventArgs e)
    {
       foreach(var e in GetCurrentPage())
       {
          // elements in current page
       }
    }
