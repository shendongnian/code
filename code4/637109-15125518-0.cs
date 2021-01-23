    // need this for Task
    using System.Threading.Tasks;
    ...
    // note async keyword added to function signature
    async private void Button_Click(object sender, RoutedEventArgs e)
    {
        comboBox1.Visibility = Windows.UI.Xaml.Visibility.Visible;
        // add small delay before opening dropdown
        await Task.Delay(1);
        comboBox1.IsDropDownOpen = true;
    }
