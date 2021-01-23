    public class Musics : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
       private void initialiseAlbums()
       {
           if (selectedArtist != null)
           {
                //Your code
                OnPropertyChanged("Albums");
           }
        }
    }
