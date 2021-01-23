    Thread1.AcqrireReadLock();
    Thread1.ComplexGetterMethod();
    Thread2.ReadIsReaderLockHeldProperty();
    Thread1.ReleaseReadLock();
    Thread2.ComplexGetterMethod(); // performing read without lock.
