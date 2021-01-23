    public class FileInfo : ObservableObject
    {
      private string _programName;
      public string programName
      {
          get{ return this._programName;}
          set
          {
              this._programName = value;
              RaisePropertyChanged(() => this.programName);
          }
       }
    }
 
