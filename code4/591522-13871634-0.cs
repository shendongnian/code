            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
        
            var myFiles = new DirectoryInfo(location).EnumerateFiles()
                .Where(f => DateTime.Parse(System.IO.Path.GetFileNameWithoutExtension(f.Name).Replace("Prefix", "")) >= startDate
                && DateTime.Parse(System.IO.Path.GetFileNameWithoutExtension(f.Name).Replace("Prefix", "")) <= endDate); 
