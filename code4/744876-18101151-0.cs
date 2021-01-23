    System.IO.Directory.GetFiles(
        @"..\DATA\data", "*.pdf").
        ToList().
        ForEach(
            item => 
            {
                if (item.Contains("TOPRINT"))
                    System.IO.File.Delete(item);
            }
        );
