    void Main()
    {
        Image bmp1 = Clipboard.GetImage();
        Image bmp2 = Clipboard.GetImage();
    
        if(bmp1 != null && bmp1 == bmp2)
            Console.WriteLine("True");
        else
            Console.WriteLine("False");
    }
