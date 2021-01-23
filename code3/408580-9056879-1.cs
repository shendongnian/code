    public ObservableCollection<ImageSource> Images
    {
        get 
        {
            return new ObservableCollection<ImageSource>(ImageSources);
        }
    }
    
    IEnumerable<ImageSource> ImageSources
    {
        get
        {
            var random = new Random(seed);
    
            for (int i = 0; i < 150; i++)
            {
                yield return MakeImage(random);
            }
        }
    }
