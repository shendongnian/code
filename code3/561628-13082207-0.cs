    // define the delegate
    public delegate int PictureDelegate(int value)
    // define your passMe function (in the class MyClass for example)
    public int passMe(int value)
    {
        return value + 1;
    }
    // when you want to use it
    MyClass myInstance = new MyClass();
    PictureDelegate passFunc = new PictureDelegate(myInstance.passMe);
    myDll.uploadPic(passFunc, 12);
