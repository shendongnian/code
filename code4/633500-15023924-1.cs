    public class ExcelEngineInterop : ISSinterface
    { ... }
    public class OOEngineInterop : ISSinterface
    { ... }
    //cant use two variables with the same name, so use 1 interface reference instead
    ISSinterface ssInt;
    if(ExcelFlag)
        ssInt = new ExcelEngineInterop();
    else
        ssInt = new OOEngineInterop();
    //two VERY different functions between Excel and OpenOffice.
    ssInt.OpenApp();
    ssInt.OpenFile(fileName);
   
    //etc etc and so on
    
