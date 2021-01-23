    public class MainMenuViewModel
        : MvxViewModel
    {
        private const string path = "myimage";
        public List<SquareModel> Items { get; set; }
        public IMvxCommand ShowItemCommand
        {
            get
            {
                return new MvxRelayCommand<Type>((type) => this.RequestNavigate(typeof(MainMenuViewModel)));
            }
        }
        public MainMenuViewModel()
        {
            Items = GetCollection();
        }
        public List<SquareModel> GetCollection()
        {
            List<SquareModel> col = new List<SquareModel>();
            for (int i = 0; i < 20; i++)
            {
                col.Add(new SquareModel { ID = i, PathImage = path });
            }
            return col;
        }
    }
