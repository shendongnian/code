        public static readonly DependencyProperty MyStyleProperty = 
            DependencyProperty.Register(
                "MyStyle",
                typeof(Style), 
                typeof(MainButton), 
                new PropertyMetadata(
                        // using this construct as a default value 
                        // makes VS 2010 SP1 to crush!
                        Application.Current.Resources["SomeStyle"] as Style, 
                        OnPropertyChanged
                )
            );
