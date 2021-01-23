    void Windows_Loaded(....)
    {
        bool i = value_from_database(); //------- Line No. 1
        checkBox1.Checked -= new RoutedEventHandler(checkBox1_Checked); //Line No. 2
        checkbox1.Ischecked = i; //------- Line No. 3
        checkBox1.Checked += new RoutedEventHandler(checkBox1_Checked); //Line No. 4
    }
