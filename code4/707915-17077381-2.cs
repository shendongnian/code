    Test t = new Test()
    {
        Data = "DERP!"
    };
    Clipboard.SetDataObject(new DataObject("Test", t));
    Test newT = (Test)Clipboard.GetDataObject().GetData("Test");
    Console.WriteLine(newT.Data);
