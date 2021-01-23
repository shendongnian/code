    private ObservableCollection<String> _actionList; 
    public ObservableCollection<String> ActionList {
      get { 
        if (_actionList == null) {
          _actionList = new ObservableCollection<String>();
        }
        
        return actionList; 
      }
    }
           
    private void populateActionList(){
      if (this.action == 0) {
        ActionList.Clear();
               
        ActionList.Add("Chinese");
        ActionList.Add("Indian");
        ActionList.Add("Malay");
        ActionList.Add("Indian");
      }
      if (this.action == 1){
        ActionList.Clear();
        ActionList.Add("Dog");
        ActionList.Add("Cats");
        ActionList.Add("Pigs");
        ActionList.Add("Horses");
        ActionList.Add("Fish");
        ActionList.Add("Lion");
      }
    }
