        System.Threading.ThreadPool.QueueUserWorkItem(foo => LauchTaskRunner());
    Suppose you implemented a method called LaunchTaskRunner which in a loop just processes the list of existing Tasks, the above line will start it into a separate process. You can communicate with this method (which is running in a separate thread) through some static variable (declared in the page), e.g.:
        public class YourPage : System.Web.UI.Page{
            static IList<Task> tasks;
            static void LauchTaskRunner(){
            // here make use of tasks variable
            }
        }
      Everytime the (tasks)updatepanel gets refreshed, it should render based on **tasks** variable.
