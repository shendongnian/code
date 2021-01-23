    private List<Image> CollectionOfPictures;
    
    public List<Image> ReturnPictures(List<Image> pics)
    {
        CollectionOfPictures = new List<Image>();
        foreach (Image image in pics)
        {
            CollectionOfPictures.Add(image);
        }
        return CollectionOfPictures;
    }
