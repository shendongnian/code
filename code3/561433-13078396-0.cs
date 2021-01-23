            foreach (var int i = 0; i < years.Length; i++)
            {
                if (string.IsNullOrEmpty(years[i]))
                    System.Diagnostics.Debug.WriteLine("empty");
                else
                {
                    yearList.SetValue(years[i], i);
                }
            }
