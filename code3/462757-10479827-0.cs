    String exactString = "ABC@@^^@@DEF";
    string[] splits = exactString.Split(new string[]{"@@^^@@"}, StringSplitOptions.None);
    string getText1 = splits[0];
    string getText2 = splits[1];
    MessageBox.Show(getText1);
    MessageBox.Show(getText2);
