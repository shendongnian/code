    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string sourceFile = @"\\HOMESERVER\Development Backup\Software\Microsoft\en_expression_studio_4_premium_x86_dvd_537029.iso";
        string destinationFile = "G:\\en_expression_studio_4_premium_x86_dvd_537029.iso";
        MoveFile(sourceFile, destinationFile);
    }
    private async void MoveFile(string sourceFile, string destinationFile)
    {
        try
        {
            using (FileStream sourceStream = File.Open(sourceFile, FileMode.Open))
            {
                using (FileStream destinationStream = File.Create(destinationFile))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                    if (MessageBox.Show("I made it in one piece :), would you like to delete me from the original file?", "Done", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        sourceStream.Close();
                        File.Delete(sourceFile);
                    }
                }
            }
        }
        catch (IOException ioex)
        {
            MessageBox.Show("An IOException occured during move, " + ioex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An Exception occured during move, " + ex.Message);
        }
    }
