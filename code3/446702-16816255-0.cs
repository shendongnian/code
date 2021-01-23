    class Form1:System.Windows.Form, INotifyPropertyChanged{
     public event PropertyChangedEventHandler PropertyChanged;
     private loadFileName;
     public LoadFileName{
       get{
           return loadFileName;
       }
       set{
           if(this.loadFileName == value ) return;
           this.loadFileName = value;
           NotifyPropertyChanged("LoadFileName");
       }
     }
     public Form1(){
       Initalize();
       this.textbox1.DataBindings.Add("Text",this,"LoadFileName");
     }
     public NotifyPropertyChanged(string propertyName){
       
       if (PropertyChanged != null)
       {
           PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
       }
     }
    }
