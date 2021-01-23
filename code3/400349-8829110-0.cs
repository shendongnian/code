    public class FormBase : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SettingControls();
        }
    
        // Declare as virtual to allow inheritors to override
        public virtual void SettingControls()
        {
            // Code here
        }
    }
