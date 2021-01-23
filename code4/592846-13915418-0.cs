    [StructLayout(LayoutKind.Sequential)]
    
    public class TCardDB
    
    {
    
    public TCardDB(string strCardNo)
    
    {
    
    CardNo = strCardNo;
    
    FName = LName = string.Empty;
    
    OpenMode = FingerCount = 0;
    
    Finger1 = new string[3];
    
    Finger2 = new string[3];
    
    }
    
    ..........
    
    ..........
    
    }
