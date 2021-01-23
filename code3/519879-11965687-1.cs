    // EXAMPLE OUTPUT
    GetSizeReadable(1023); // 1023 B
    GetSizeReadable(1024); // 1 KB
    GetSizeReadable(1025); // 1.001 KB
    // Example of getting a file size and converting it to a readable value
    string fileName = "abc.txt";
    long fileSize = new System.IO.FileInfo(fileName).Length;
    string sizeReadable = GetSizeReadable(fileSize);
