    public class AnswersViewModel : ViewModelBase // From MvvmLight
    {
        public bool IsAnswered
        {
            get { return _isAnswered; }
            set
            {
                if(value == _isAnswered)
                    return;
                _isAnswered = value;
                if(_isAnswered)
                {
                    Answer1 = "0";
                    Answer2 = "0";
                }
                
                RaisePropertyChanged("IsAnswered");
            }
        }
        
        public string Answer1
        {
            get { return _answer1; }
            set
            {
                if(value == _answer1)
                    return;
                
                _answer1 = value;
                RaisePropertyChanged("Answer1");
                if(_answer1 == "0" && _answer2 == "0")
                {
                    _isAnswered = true;
                    RaisePropertyChanged("IsAnswered");
                }
            }
        }
        
        // Answer2 is the same as Answer1
    }
