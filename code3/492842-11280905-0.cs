    for (int i = 0; i < 1000000; i++)
    {
       using (BinaryWriter writer = new BinaryWriter(stream)) 
       // this will force disposing of writer, but will also close the base 
       // stream instance too. 
       {
               // In or out?
               try
               {
                  mutex.WaitOne();
                  writer.Write(i);
                  mutex.ReleaseMutex();
               }
               catch (Exception e)
               {
                   Console.WriteLine(e);
               }
        }
     }
