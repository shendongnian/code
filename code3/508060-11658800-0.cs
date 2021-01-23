    string[] arr = new string[] { "","A"};
    
                for (int i = 0; i < arr.Length; i++)
                {
                    if (string.IsNullOrEmpty(arr[i]))
                    {
                        arr[i] = "Hello";
                    }
                }
