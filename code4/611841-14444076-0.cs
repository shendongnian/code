    public static async void GetStations()
    {
        try
        {
            using (var stream = await Windows.ApplicationModel.Package.Current.InstalledLocation.OpenStreamForReadAsync(@"Data\file.txt"))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        string line = await streamReader.ReadLineAsync();
                        //do something with 
                    }
                }
            }
        }
        catch (Exception e)
        {
            //...
        }
        finally
        {
            //...
        }
    }
