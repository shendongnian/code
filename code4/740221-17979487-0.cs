    using (var stream = System.IO.File.Open(file, System.IO.FileMode.Open))
    { 
        var data = new byte[8]; // temp variable to hold byte data from stream
        for(var x = 0; x < count; ++x)
        {
            stream.Read(data, 0, 8);
            num = System.BitConverter.ToDouble(data, 0); // convert bytes to double
            // do something with num
        }
    }
