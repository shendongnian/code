        public static readonly DependencyProperty FrontBackgroundProperty =
            DependencyProperty.Register("FrontBackground", typeof(Brush), typeof(Tile),
            new PropertyMetadata(new SolidColorBrush((Color)Application.Current.Resources["PhoneAccentColor"])));
        public static readonly DependencyProperty BackBackgroundProperty =
            DependencyProperty.Register("BackBackground", typeof(Brush), typeof(Tile),
            new PropertyMetadata(new SolidColorBrush((Color)Application.Current.Resources["PhoneAccentColor"])));
