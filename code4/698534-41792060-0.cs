    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        bool Chked = Convert.ToBoolean((sender as CheckBox).IsChecked);
        string ChkBoxContent = (sender as CheckBox).Content.ToString();
        TxtHabitsHx.AppendText(ChkBoxContent);
    }
