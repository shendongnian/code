        private async void LaunchExcel(object sender, RoutedEventArgs e)
        {
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("myExcelFile.xlsx");
            using (var s = await file.OpenAsync(FileAccessMode.ReadWrite))
            using (var dw = new DataWriter(s))
            {
                dw.WriteString("hello world");
            }
            await Launcher.LaunchFileAsync(
                await ApplicationData.Current.LocalFolder.GetFileAsync("myExcelFile.xlsx"));
        }
