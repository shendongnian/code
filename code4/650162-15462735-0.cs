    try {
        // code goes here
    } catch(System.IO.FileNotFoundException ex) {
        Console.WriteLine(
            String.Format("(HRESULT:0x{1:X8}) {0}",
                          ex.Message,
                          ex.HResult)
        );
    }
