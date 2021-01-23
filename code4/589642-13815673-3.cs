        using (var file = File.CreateText(path))
        {
            foreach (var arr in lst)
            {
                if (String.IsNullOrEmpty(arr)) continue;
                file.Write(arr[0]);
                for(int i = 1 ; i < arr.Length ; i++)
                {
                    file.Write(',');
                    file.Write(arr[i]);
                }
                file.WriteLine();
            }
        }
