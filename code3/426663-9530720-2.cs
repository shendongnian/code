    [Fact]
    public void AddNewItem()
    {
        var hashTable = new MyHashTable();
    
        hashTable.Add("hello", "world");
    
        Assert.True(hashTable.Exists("hello"));
        Assert.Equal("world", hashTable["hello"]);
    }
    
    [Fact]
    public void AddExistingItem()
    {
       var hashTable = new MyHashTable();
    
       hashTable.Add("hello", "world");
       hashTable.Add("hello", "realItem");
    
       Assert.Equal("realItem", hashTable["hello"]);
    }
