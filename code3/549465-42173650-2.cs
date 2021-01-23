        public class FooViewModel : ViewModelBase
        {
            public FooViewModel()
            {
                Widget = new MegaWidget
                {
                    Locations = new Dictionary<string, Location>
                    {
                        [ "Front" ] = new Location
                        {
                            Contents = new List<Part>
                            {
                                new Part { Id = 1, PartName = "Part 01" },
                                new Part { Id = 2, PartName = "Part 02" },
                                new Part { Id = 3, PartName = "Part 03" },
                            }
                        },
                        [ "Back" ] = new Location
                        {
                            Contents = new List<Part>
                            {
                                new Part { Id = 11, PartName = "Part 11" },
                                new Part { Id = 12, PartName = "Part 12" },
                                new Part { Id = 13, PartName = "Part 13" },
                            }
                        },
                    }
                };
            }
            public MegaWidget Widget { get; }
            #region Property FrontPart
            private Part _frontPart;
            public Part FrontPart
            {
                get { return _frontPart; }
                set { SetProperty( ref _frontPart, value ); }
            }
            #endregion
            #region Property BackPart
            private Part _backPart;
            public Part BackPart
            {
                get { return _backPart; }
                set { SetProperty( ref _backPart, value ); }
            }
            #endregion
        }
