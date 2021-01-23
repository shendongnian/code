     public class ScoreboardData :IScoreboardData, System.ComponentModel.INotifyPropertyChanged
     {
         public event PropertyChangedEventHandler PropertyChanged;
         private string _title;
         public string Title
          {
              get { return _title; }
              set 
              {
                  _title = value; 
                   if(PropertyChanged!=null)
                      PropertyChanged(this,new PropertyChangedEventArgs("Title"));
              }
           }                
      } 
