        public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Member Variables
        private List<Square> worldMapGrid = new List<Square>();
        #endregion
        #region Ctr
        public MainWindowViewModel()
        {
            BuildWorldMap();
        }
        #endregion
        #region Public Methods
        #endregion
        #region Private Methods
        private void BuildWorldMap()
        {
            MapGrid.Add(new SquareDesert());
            MapGrid.Add(new SquareDesert());
            MapGrid.Add(new SquareDesert());
            MapGrid.Add(new SquareDesert());
            
            MapGrid.Add(new SquareMountain());
            MapGrid.Add(new SquareMountain());
            MapGrid.Add(new SquareMountain());
            MapGrid.Add(new SquareMountain());
            
            MapGrid.Add(new SquarePrairie());
            MapGrid.Add(new SquarePrairie());
            MapGrid.Add(new SquarePrairie());
            MapGrid.Add(new SquarePrairie());
            
            MapGrid.Add(new SquarePrairie());
            MapGrid.Add(new SquarePrairie());
            MapGrid.Add(new SquarePrairie());
            MapGrid.Add(new SquarePrairie());
        }
        private void RaisePropertyChanged([CallerMemberName] string _propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_propertyName));
            }
        }
        #endregion
        #region Properties
        public List<Square> MapGrid
        {
            get
            {
                return this.worldMapGrid;
            }
            set
            {
                this.worldMapGrid = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
