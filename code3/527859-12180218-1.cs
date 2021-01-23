    public partial class TestControl : UserControl, IModuleTile
    {
        //You'll need to change `EventHandler` here too, if you changed it above
        public event EventHandler MyClick
        {
            add
            {
                ShowModule.Click += value;
            }
            remove
            {
                ShowModule.Click -= value;
            }
        }
    }
