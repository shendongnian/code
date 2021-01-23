    public class Producer{ 
        public static int GetValue(){
        //... long running operation
        }
    }
    
    
    public class FormConsumer{
    
    
       public void GetMeValue(){
           int v = 0;
           ((Action) (() => { v = Producer.GetValue(); }))
              .BeginInvoke((a) => {
                  this.Invoke((MethodInvoker)delegate{ GotTheValue(v)});
              }, null); 
       }
       public void GotTheValue(int v){
         // called on UI thread 
       }
    }
