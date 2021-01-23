    public class Students: Form
    {
        private static Students _Self;
        public static Students ShowOrActivate(Form parent)
        {
            if (_Self == null)
            {
                _Self = new Students();
                _Self.MdiParent = this;
                _Self.Show();
            }
            else
                _Self.Activate();
        }
    }
