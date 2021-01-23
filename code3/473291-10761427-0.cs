    public class theBase
    {
        string ID;
        string Description;
    }
    public class theColor : theBase
    {
    }
    public class theType : theBase
    {
    }
    public void ExFunctionSaveA(theBase base)    
    {
        base.ID=1;
        base.Description="My Color";
        Save();
    }
