    using System.Threading.Tasks;
    
    public void SavePhoto(CancellationTokenSource taskCancellationTokenSource){
    
       // preliminary code
    
       // start resize
       Task resizeTask =  Task.Factory.StartNew( ResizePhoto, taskCancellationTokenSource ) ;
    
       // queue up final save method
       Task finalTask = resizeTask.ContinueWith(t => {
         if (!t.IsFaulted && !t.IsCancelled){
             FinishSaving();
         }
       });
    
       // Wait for everything to finish
       finalTask.Wait(taskCancellationTokenSource);
    }
    
    public void ResizePhoto(){
      // code
    }
    
    public void FinishSaving(){
       // code
    }
