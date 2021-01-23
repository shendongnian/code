    using System.Threading.Tasks;
    public class BackgroundThread {
        IView _view;
        TaskScheduler _uiThreadScheduler;
        // This object is constructed on the main thread. The main thread's TaskScheduler
        // can be acquired with TaskScheduler.FromCurrentSynchronizationContext()
        public BackgroundThread(IView view, TaskScheduler uiThreadScheduler){
            this._view = view;
            this._uiThreadScheduler = uiThreadScheduler;
        }
        public void DoWork(){
            // Code in this function executes on a background thread
            //...
            string filename;
            var task = Task.Factory.StartNew(() =>
            {
                filename = _view.GetSaveFilename();
            }, CancellationToken.None, TaskCreationOptions.None, _uiThreadScheduler);
            task.Wait();
            // filename now has input from the user, or is null
        }
    }
