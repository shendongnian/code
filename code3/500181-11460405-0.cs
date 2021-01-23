    public abstract class BaseUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception)
            {
                //Custom error handling here
            }
        }
        
        protected abstract void OnLoad();
    }
    
    public class MyUserControl: BaseUserControl
    {
        protected override void OnLoad()
        {
            //My normal load event handling here
        }
    }
