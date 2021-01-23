    public object ValueAorB
    {
        get
        {
            if (values[0] != DependencyProperty.UnsetValue && values[0] != null && !string.IsNullOrEmpty(values[0].ToString()))
            {
                Debug.WriteLine("values 0: " + values[0]);
                return values[0].ToString();
            }
            if (values[1] != DependencyProperty.UnsetValue && values[1] != null && !string.IsNullOrEmpty(values[1].ToString()))
            {
                Debug.WriteLine("values 1: " + values[1]);
                return values[1].ToString();
            }
        }
    }
