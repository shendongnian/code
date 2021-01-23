    private async void Label_FindingPart_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        sound.Source = new Uri(@"C:\SomeSound.wav");
        sound.Position = TimeSpan.Zero;  
        sound.Play();
        await Task.Delay(1000);
        Button_Logistics.Visibility = Visibility.Visible;
        await Task.Delay(500);
        Image_SAP_Main.Visibility = Visibility.Hidden;
        Image_SAP_Main_Logistics.Visibility = Visibility.Visible;
        Button_Logistics.Visibility = Visibility.Hidden;
        await Task.Delay(500);
        Button_MMBE.Visibility = Visibility.Visible;
        await Task.Delay(500);
        Image_SAP_Main_Logistics.Visibility = Visibility.Hidden;
        Button_MMBE.Visibility = Visibility.Hidden;
        Image_SAP_MMBE.Visibility = Visibility.Visible;
    }
