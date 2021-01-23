    public class ViewModelDataLoader : IViewModelDataLoader{
        private IList<AssignData> callbacksToCall;
        private bool isLoading;
        public void LoadData(AssignData callback){
            callbacksToCall.add(callback);
            if (isLoading) { return; }
            // Do some long running code here
            var data = something;
            // Now iterate the list
            foreach(var item in callbacksToCall){
               item(data);
            }
            isLoading = false;
        }
     }
  
