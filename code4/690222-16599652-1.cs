    public class MessageNotifier{
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
       //I Handle all messages with this signature and if the message applies to me do something
       //
       public void Handle(MesssageNotifier _notifier){
            if(_notifier.Message == "NewSelectedItem"){
                //do something with the content of the selectedItem
                var x = _notifier.Content
            }
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
          set{ _someobject = value;
              NotifyOfPropertyChange(()=>SelectedItem);
              _eventAggregator.Publish(new MessageNotifier(){ Content = SelectedItem, Message="NewSelectedItem"});
        }
    }
