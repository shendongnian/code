    MyTextBox.KeyDown += (s, a) => {
        if (a.Key == VirtualKey.Enter) {
            MyTextBox.IsEnabled = false;
            MyTextBox.IsEnabled = true;
        }
    };
