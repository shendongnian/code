    if (listTime.SelectedIndex != -1)
    {
        var item = listTime.SelectedItem as Duration;
        //or as suggested by 'Stu'
        var item = (Duration)listTime.SelectedItem;
        MessageBox.Show(item.Value.ToString());
    }
