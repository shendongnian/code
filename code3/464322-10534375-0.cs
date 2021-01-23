    public class uiBrowserWindow : BrowserWindow {
        public void launchUrl(string url) {
            try {
                SearchProperties[PropertyNames.ClassName] = "IEFrame";
                NavigateToUrl(new Uri(url));
            } catch (Exception) {
                Launch(url);
        }
    }
