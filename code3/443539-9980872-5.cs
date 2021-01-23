    [Export(typeof (DialogViewModel))]
        public class DialogViewModel : Screen
        {
            private string _dimension1;
            public string Dimension1
            {
                get { return _dimension1; }
                set
                {
                    _dimension1 = value;
                    NotifyOfPropertyChange(() => Dimension1);
                }
            }
            private string _dimension2;
            public string Dimension2
            {
                get { return _dimension2; }
                set
                {
                    _dimension2 = value;
                    NotifyOfPropertyChange(() => Dimension2);
                }
            }
    
            public void Ok()
        {
            //Do stuff
            MyDialogResult = DialogResult.OK;
            TryClose();
        }
        public void Cancel()
        {
            MyDialogResult = DialogResult.Cancel;
            TryClose();        
        }
 
