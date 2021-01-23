    private List<Image> CollectionOfPictures;
    public List<Image> ReturnPictures(List<Image> pics)
    {
        return CollectionOfPictures.Concat(pics).ToList();
    }
