    public class MyWindow
    {
        public bool ShouldLabelBeDisplayed { get; set; }
        public void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(...);
            if (dialogResult == DialogResult.Yes)
            {
                ShouldLabelBeDisplayed = true;
            }
            else
            {
                ShouldLabelBeDisplayed = false;
            }
        }
