     <StackPanel Background="Red" MinHeight="80"  VerticalAlignment="Top" Tap="StackPanel_Tap_1" Orientation="Horizontal">
        		<Button x:Name="btn1" Content="Button"/>
                <Button x:Name="btn2" Content="Button"/>
                <TextBox Height="72" x:Name="textbox1" TextWrapping="Wrap" Text="TextBox" Width="456"/>
        	</StackPanel> 
     private void StackPanel_Tap_1(object sender, GestureEventArgs e)
        {
            if (btn1.IsEnabled==false)
            {
                btn1.IsEnabled = true;
                btn1.Visibility = Visibility.Visible;
                btn2.Visibility = Visibility.Visible;
                textbox1.Visibility = Visibility.Visible;
            }
            else
            {
                btn1.IsEnabled = false;
                btn1.Visibility = Visibility.Collapsed;
                btn2.Visibility = Visibility.Collapsed;
                textbox1.Visibility = Visibility.Collapsed;
            }
            
        }
