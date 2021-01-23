    public class SomeObject{
      public object Content{get;set;}
      public string Message {get;set;}
    }
    //MEF bits here
    public class HelloWorldViewModel: Screen, IHandle<SomeObject>{
       private readonly IEventAggregator _eventAggregator
       
      //MEF constructor bits
      public YourViewModel(IEventAggregator eventAggregator){
        _eventAggregator = eventAggregator;
      }
       public override OnActivate(){
           _eventAggregator.Subscribe(this);
       }
       public override OnDeactivate(){
         _eventAggregator.UnSubscribe(this);
       }
       public void Handle(SomeObject someObject){
            
       } 
    }
    
    //MEF attrs
    public class HelloWorld2ViewModel: Screen{
       private readonly IEventAggregator _eventAggregator
        //MEF attrs
        public HelloWorld2ViewModel(IEventAggregator eventAggregator){
           _eventAggregator = eventAggregator;
        }
        
        public someobject SelectedItem{
          get{ return _someobject ;}
        }
    }
