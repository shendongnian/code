     private void Generator(input)
     {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            Helper.Instance.Manipulate(memoryStream);
        }
     }
