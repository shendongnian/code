    var data = new SharedData
    {
        Id = 1,
        Value = 0
    };
 
    var mutex = new Mutex(false, "MmfMutex");
 
    using (var mmf = MemoryMappedFile.CreateOrOpen("MyMMF", Marshal.SizeOf(data)))
    {
         using (var accessor = mmf.CreateViewAccessor())
         {
              while (true)
              {
                  mutex.WaitOne();
                  accessor.Write(0, ref data);
                  mutex.ReleaseMutex();
 
                  Console.WriteLine($"Updated Value to: {data.Value}");
                  data.Value++;
                  Thread.Sleep(1000);
               }
         }
    }
