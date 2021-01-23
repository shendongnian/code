    public static string GetStringOfData<T>(List<T> data)
            {
                StringBuilder dataBuilder = new StringBuilder();
                foreach (object o in data)
                {
                    dataBuilder.Append(o.ToString());
                    dataBuilder.Append(" ");
                }
    
                return dataBuilder.ToString();
            }
