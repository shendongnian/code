    public class GameSquare : MvxNotifyProperty
    {
        private string _icon;
        public string Icon 
        {
           get { return _icon; }
           set { _icon = value; RaisePropertyChanged(() => Icon);
        }
    }
