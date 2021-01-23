    public class RibbonViewModel {  
        IEventAggregator events;  
      
        public RibbonViewModel (IEventAggregator events){  
            this.events = events;  
        }  
      
        public void ButtonClickCommandExecute(){  
            events.Publish(new SomeMessage{  
                SomeNumber = 5,  
                SomeString = "Blah..."  
            });  
        }  
    }
