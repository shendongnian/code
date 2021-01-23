    public string Symbol
        {
            get
            {
                return (string)GetValue(SymbolProperty);
            }
            set
            {
                SetValue(SymbolProperty, value);
            }
        }
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register
            (
                "Symbol",
                typeof(string),
                typeof(SymbolStatsViewModel),
                new FrameworkPropertyMetadata
                (
                    string.Empty
                )
            );
