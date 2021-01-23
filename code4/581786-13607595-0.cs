        byte[] array=null;
        List<float> myData = new List<float>();
        myData.Add(43.1f);
        myData.Add(42.1f);
        myData.Add(41.1f);
        myData.Add(40.1f);
        foreach (float a in myData)
           array = BitConverter.GetBytes(a);
        //printing
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
