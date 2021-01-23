            myComboBox.Items.Add("Item1");
            myComboBox.Items.Add("Item2");
            myComboBox.Items.Add("Item3");
            myComboBox.SelectedIndex = 1; //force change selection
            Console.WriteLine(myComboBox.SelectedItem.ToString()); //will output Item2
