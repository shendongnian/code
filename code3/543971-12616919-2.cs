    Assembly SampleAssembly = Assembly.Load("ExcelBridge", Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c");
    
    if (SampleAssembly != null)
    {
        Assembly YourExcelAssembly = Assembly.Load("ExcelBridge.dll");
        Type type = YourExcelAssembly .GetType("ExcelApp");
        IExcel AppClass = Activator.CreateInstance(type) as IExcelApp;
    
       //now you can write:
       IExcelWorkBook aWbk = AppClass.Open("your xls path");
    }
