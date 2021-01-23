    public void RemoveAndDisposeFromDictionary(Dictionary<int, RPicture> dict, int index)
    {
        var myRImage = dict[index];              
        dict.Remove(index);
        myRImage.Dispose();
    }
