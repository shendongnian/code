    [ComVisible(true)]
    public class JavascriptBridge {
        public void Notify(string data) {
            try {
                // Process the data
            } catch (Exception ex) {
                System.Threading.ThreadPool.QueueUserWorkItem((state) => {
                    throw new Exception("An unhandled exception ocurred while servicing a Javascript method call.", ex);
                });
            }
        }
    }
