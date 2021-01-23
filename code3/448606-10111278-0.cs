       //getter and setter sample(grabbing them from the question)
        get
        {
            if (Visibility == System.Windows.Visibility.Hidden)
            {
                return 0;
            }
            return base.Width;
        }
        set
        {
            base.Width = value;
        }
    }
