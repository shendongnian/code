    public void ItemInsert(string name,
                           string creator,
                           string publishing,
                           string itemType,
                           string genre,
                           string year) {
        // ...
        if (errorMsg.Length != 0) {
           throw new ItemInsertError(errorMsg);
        }
    }
