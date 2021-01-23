    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            StackSG = new List<TextBox>();
            StackSGName = new List<TextBox>();
            Generate(null);
        }
        private IEnumerable stackSG;
        public IEnumerable StackSG
        {
            get { return stackSG; }
            set
            {
                stackSG = value;
                OnNotifyPropertyChanged("StackSG");
            }
        }
        private IEnumerable stackSGName;
        public IEnumerable StackSGName
        {
            get { return stackSGName; }
            set
            {
                stackSGName = value;
                OnNotifyPropertyChanged("StackSGName");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnNotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private void Generate(object obj)
        {
            IList<TextBox> StackSGTmp = new List<TextBox>();
            IList<TextBox> StackSGNameTmp = new List<TextBox>();
            int st = 10;
            for (int i = 0; i < st; i++)
            {
                TextBox txtSG = new TextBox();
                txtSG.Name = string.Format("{0}{1}", "Te", i.ToString());
                txtSG.Height = 25;
                txtSG.Text = string.Format("{0}{1}", "Te", i.ToString());
                txtSG.IsReadOnly = true;
                StackSGTmp.Add(txtSG);
                //Add SG name textboxes                        
                TextBox txtSGName = new TextBox();
                txtSGName.Name = string.Format("{0}{1}", "Test", i.ToString());
                txtSGName.Height = 25;
                txtSGName.Text = string.Format("{0}{1}", "Test", i.ToString());
                txtSGName.IsReadOnly = true;
                StackSGNameTmp.Add(txtSGName);
            }
            StackSG = StackSGTmp;
            StackSGName = StackSGNameTmp;
        }
    }
