            public class ViewModel
        {
            public ViewModel()
            {
                ButtonClickCommand = new RelayCommand(Validate);
            }
            private void Validate()
            {
                if (Text1.Length > 127) 
                    throw new ArgumentException();
                if (string.IsNullOrEmpty(Text2)) 
                    ErrorList.Add("You must to fill out textbox2");
                else if (string.IsNullOrEmpty(Text3)) 
                    ErrorList.Add("You must to fill out textbox3");
                else
                {
                    Regex regex = new Regex(@".........");
                    Match match = regex.Match(Email);
                    if (!match.Success) ErrorList.Add("e-mail is inlvalid");
                }
            }
            public string Text1 { get; set; }
            public string Text2 { get; set; }
            public string Text3 { get; set; }
            public string Email { get; set; }
            public ObservableCollection<string> ErrorList { get; set; }
            public ICommand ButtonClickCommand { get; private set; }
        }
