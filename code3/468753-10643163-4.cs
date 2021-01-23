    public ObservableCollection<ISocialContact> Contacts { get; set; }
    ...
    Contacts = new ObservableCollection<ISocialContact> {
                        new FacebookContact { Name = "Face", FacebookPage = "book" },
                        new TwitterContact { Name = "Twit", TwitterAccount = "ter" } 
               };
