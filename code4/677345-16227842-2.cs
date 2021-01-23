    public class GridRobotViewModel: PropertyChangedBase
    {
        private int _size;
        public int Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
                CreateItems();
            }
        }
        private ObservableCollection<GridItem> _squares;
        public ObservableCollection<GridItem> Squares
        {
            get { return _squares ?? (_squares = new ObservableCollection<GridItem>()); }
        }
        private ObservableCollection<GridItem> _route;
        public ObservableCollection<GridItem> Route
        {
            get { return _route ?? (_route = new ObservableCollection<GridItem>()); }
        }
        private void CreateItems()
        {
            Squares.Clear();
            Route.Clear();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Squares.Add(new GridItem() {Row = i, Column = j});
                }
            }
        }
        private Command<GridItem> _goToCommand;
        public Command<GridItem> GoToCommand
        {
            get { return _goToCommand ?? (_goToCommand = new Command<GridItem>(Goto){IsEnabled = true}); }
        }
        private void Goto(GridItem item)
        {
            if (item.PathIndex == null)
            {
                item.PathIndex = Squares.Max(x => x.PathIndex ?? 0) + 1;
                Route.Add(item);    
            }
        }
    }
