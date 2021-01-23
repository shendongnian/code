    //Wait for enough memory
    var temp = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");
    long freeMemory = Convert.ToInt64(temp.NextValue()) * (long)1000000;
    long neededMemory = (long)bytesToAllocate;
    int attempts=1200; //two minutes
                            
    while (freeMemory < neededMemory)
    {
         //Signal that memory needs to be freed
         Console.WriteLine("Waiting for enough free memory:. Free Memory:" + freeMemory + " Needed Memory(MB):" + neededMemory);
         System.Threading.Thread.Sleep(100);
         freeMemory = Convert.ToInt64(temp.NextValue()) * (long)1000000;
         --attempts;
        
         if (0 == attempts)
              throw new OutOfMemoryException("Could not get enough free memory. File:" + Path.GetFileName(wavFileURL));
    }
    //Try and allocate the memory we need.
