    <ComboBox Loaded="ComboBox_Loaded">
        <ComboBox.Items>
            <ComboBoxItem Content="111" />
        </ComboBox.Items>            
    </ComboBox>
.
	private void ComboBox_Loaded(object sender, RoutedEventArgs e)
	{
		(sender as ComboBox).Text = "111";
	}
