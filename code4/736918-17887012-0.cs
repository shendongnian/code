    public void RemoveAndDisposeFromDictionary(Dictionary<int, RPicture>, int index)
    {
        var myRImage = RPictureDictionary[index];              
        RPictureDictionary.Remove(index);
        myRImage.image.Dispose();
    }
