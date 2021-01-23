    foreach (string name in a.Keys){
        StackPanel SP = new StackPanel();
        TextBox TB1 = new TextBox();
        TextBox TB2 = new TextBox();
        SP.Children.Add(TB1);
        SP.Children.Add(TB2);
        // ... Content to TextBoxes
        TB2.Name = name;
        MainCheckBox.Clicked += (sender, e) => {
            TB2.Height = MainCheckBox.IsChecked ? 300 : 0;
        }
    }
