    public class Producer{ 
        public static int GetValue(){
        //... long running operation
        }
    }
    
    
    public class FormConsumer{
    
    
       public void GetMeValue(){
           int v = 0;
           // setting up for async call
           Action asyncCall = () => { v = Producer.GetValue();};
           // this is the delegate that will be called when async call is done
           AsyncCallback = (acbk)=> {
                this.Invoke((MethodInvoker)delegate{ 
                    GotTheValue(v)
                });
           };
           
           // execute the call asynchronously
           asyncCall.BeginInvoke(acbk, null); 
       }
       public void GotTheValue(int v){
         // this gets called on UI thread 
       }
    }
