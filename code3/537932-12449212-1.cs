        private ICollectionView _musicsView;
        public ObservableCollection<Music> Musics{ get; private set; }
                           
        public YourViewModel()
        { 
           Musics= new ObservableCollection<Music>();
           _music= CollectionViewSource.GetDefaultView(AvaibleLanguages);
           _music.CurrentChanged += new EventHandler(OnCurrentChanged);
        }
        
        public ICollectionView MusicsView
        {
           get
           {
              return _musicsView;
           } 
        }
        
        void OnCurrentChanged(object sender, EventArgs e)
        {
            YourObject current = _musicsView.CurrentItem as YourItem;
    //do: what you want
        }
