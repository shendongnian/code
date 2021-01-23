    long StopBytes = 0;
    foo myFoo;
    long StartBytes = System.GC.GetTotalMemory(true);
    myFoo = new foo();
    StopBytes = System.GC.GetTotalMemory(true);
    GC.KeepAlive(myFoo); // This ensure a reference to object keeps object in memory
    MessageBox.Show("Size is " + ((long)(StopBytes - StartBytes)).ToString());
