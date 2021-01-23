    public static void Main()
    {
    MyWrapperClass foo = new MyWrapperClass();
    foo.sortColumnIndex =  DetailsEnum.Column1; // Set Property
    Console.Write(foo.sortColumnIndex); // Column 1
    Console.Write((int)foo.sortColumnIndex); // 1
    }
