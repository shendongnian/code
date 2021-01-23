     public ViewModel 
	 {
      private ObservableCollection<Model> models = new ObservableCollection<Model>();
      private Model selectedModel;
      public ViewModel() { }
      private Model _SelectedModel ;
	  public Model SelectedModel 
	  {
		get { return _SelectedModel??(_SelectedModel=new SelectedModel() ;}
		set { _SelectedModel  = value;}
	   }
     }
