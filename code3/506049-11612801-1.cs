    public class MyTextProducer : INotifyPropertyChanged
    {
        private string _myText;
        public string myText { get { return _myText; } set { _myText = value; RaisePropertyChanged("myText"); } }
        public MyTextProducer()
        {
            myText = string.Empty;
        }
        public void ProduceText()
        {
            string txt;
            for (int i = 0; i < 10; i++)
            {
                txt = string.Format("This is line number {0}", i.ToString());
                AddText(txt);
                Thread.Sleep(1000);
            }
        }
        private void AddText(string txt)
        {
            myText += txt + Environment.NewLine;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
