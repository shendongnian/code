       private async void search()
        {
            if (tbs.Text != null)
            {
                var files = await ApplicationData.Current.LocalFolder.GetFileAsync(logid.Text + ".txt");
                var lines = await FileIO.ReadLinesAsync(files);
                var pattern = tbs.Text;  
                var sum = 0;
                foreach (string line in lines)
                {
                    var elements = line.Split(' ');
                    int value;
                    if (int.TryParse(elements[1], out value))
                    {
                        sum += value;
                    }
                }
            }
        }
