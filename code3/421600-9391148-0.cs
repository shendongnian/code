    // Use this in real code
    public class MyClass() : MyClass(() => new ProductionEntities()) 
    {
    }
    // Use this in your test
    public class MyClass(Func<IHaveEntities> entities) 
    {
        _entities = entitites;
    }
    
    public byte[] GetScanFileFaceByMemberID(int MemberID)
    {
        byte[] scanFileFace;
        using (IHaveEntities entityContext = _entities())
        {
            scanFileFace = (from scan in entityContext.tblScan
                     where scan.MEMBERID == MemberID
                     select scan.scanFileFace).Single();
        }
        return scanFileFace;
    }
