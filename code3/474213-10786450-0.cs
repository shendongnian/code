    public MyControl : UserControl
    {
       private IBusinessLogic _logic;
       public MyControl( IBusinessLogic logic )
       {
          this._logic = logic;
       } 
       // use the _logic
    }
