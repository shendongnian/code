    public class ViewModel
    {
        private ICommand _buttonDoubeClick;
        public ICommand ButtonDoubleClick
        {
            get
            {
                if (_buttonDoubeClick == null)
                {
                    _buttonDoubeClick = new SimpleDelegateCommand(() => MessageBox.Show("Double click!!"));
                }
                return _buttonDoubeClick;
            }
        }
    }
