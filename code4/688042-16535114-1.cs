    using System;
    using Windows.Storage;
    async void test2()
    {
        
        var fileName = string.Format(@"ms-appx:///Mazes/level{0}.txt", level);
        try 
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri( "ms-appx:///assets/textfile1.txt"));
            var lines = await FileIO.ReadLinesAsync(file);
            foreach (var line in lines)
            {
                // code to process each line here
            }
        }
        catch (Exception e)
        {
             // handle exceptions
        }
