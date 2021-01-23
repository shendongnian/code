    public class GameInfo : INotifyPropertyChanged
    {
        private int _score;
	public int Score
	{
	  get
	  {
		return this._score;
	  }
	  set
	  {
		if (value != this._score)
	  {
		this._score = value;
		NotifyPropertyChanged("Score");
	  }
	}
      }    
    public int counter = 0; // if you use _score, then you don't need this variable.
        public event PropertyChangedEventHandler PropertyChanged;
      
         private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
