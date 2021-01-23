    public void InsertionSort(Player newUser)
    {
        var index = users.FindLastIndex(u => u.Name <= newUser.Name);
        users.Insert(index, newUser);
    }
