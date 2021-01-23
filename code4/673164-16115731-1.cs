    public class Commands
    {
        private static readonly ICommand _showShowBoxCommand = 
            new RelayCommand<string>(str => MessageBox.Show(str));
        public static ICommand ShowMeABox { get { return _showShowBoxCommand; } }
    }
