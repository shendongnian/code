    checkBoxI1.Invoke(new Action(() => 
    {
        checkBoxI1.IsChecked = inputs[0] == 32;
        checkBoxI2.IsChecked = inputs[1] == 32;
        checkBoxI3.IsChecked = inputs[2] == 32;
        checkBoxQ1.IsChecked = outputs[0] == 32;
        checkBoxQ2.IsChecked = outputs[1] == 32;
        checkBoxQ3.IsChecked = outputs[2] == 32;
    }));
