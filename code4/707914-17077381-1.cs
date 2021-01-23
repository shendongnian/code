    Test t = new Test()
    {
         Data = "DERP!"
    };
    Clipboard.SetData("Test", t);
    Test newT = (Test)Clipboard.GetData("Test");
    Console.WriteLine(newT.Data);
