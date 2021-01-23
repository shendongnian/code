    public class ViewModelWithDataGrid : IHandle<SomeMessage>{  
        public void Handle(SomeMessage message){  
            if(IsActive){           
            //do something with the message  
            }
        }  
    }
