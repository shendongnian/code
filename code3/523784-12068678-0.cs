    public class DiabloIICharacter : ViewModelBase
    {
        public String Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private String name;
    
        public Boolean IsBoss
        {
            get { return isBoss; }
            set
            {
                if (isBoss != value)
                {
                    isBoss = value;
                    OnPropertyChanged("IsBoss");
    
                    if (isBoss)
                        // when a character becomes a boss, it becomes selected too
                        IsSelected = true;
                }
            }
        }
        private Boolean isBoss;
    
        public Boolean IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
        private Boolean isSelected;
    }
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new[]
            {
                new DiabloIICharacter { Name = "Diablo", IsBoss = true },
                new DiabloIICharacter { Name = "Oblivion Knight", IsBoss = false },
                new DiabloIICharacter { Name = "Blood Lord", IsBoss = false },
                new DiabloIICharacter { Name = "Andariel", IsBoss = true },
                new DiabloIICharacter { Name = "Baal", IsBoss = true },
                new DiabloIICharacter { Name = "Minion of Destruction", IsBoss = false },
                new DiabloIICharacter { Name = "Megademon", IsBoss = false },
            };
        }
    }
