        try { /* Do something that generates an exception here. */ }
        catch(System.Exception exception)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, exception);
                YourWCFMethodHere(ms.ToArray());
            }
         }
