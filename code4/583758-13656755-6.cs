    private List<Image> CollectionOfPictures;
    public List<Image> ReturnPictures(List<Image> pics)
    {
        foreach (Image image in pics)
        {
            CollectionOfPictures.Add(image);
        }
        return CollectionOfPictures;
    }
