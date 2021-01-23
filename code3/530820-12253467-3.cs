    public void ProcessMyByte(byte current)
    {
        if (AreEqyal(current, CapturedP1))
               ....Do Somthing
    }
    .... Main()...
    {
    ....
    byte[] LoadedArr = File.ReadAllBytes("testFileCompare2Scr.bmp");
    Parallel.ForEach(LoadedArr, ProcessMyByte);
    ...
    }
