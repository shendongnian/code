    string inputFilename = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
    string outputFilename = inputFilename + ".secret";
    string marker = "magic".ToUpper();
    byte[] data = File.ReadAllBytes(inputFilename);
    byte[] markerData = Encoding.ASCII.GetBytes(marker);
    int markerLength = markerData.Length;
    const int blockSize = 512; //important!
    using(FileStream input = File.OpenRead(inputFilename)) {
        long lastPosition = 0;
        byte[] buffer = new byte[blockSize];
        while (input.Read(buffer, 0, blockSize) >= markerLength) {
            bool found = true;
            for (int idx = 0; idx < markerLength; idx++) {
                if (buffer[idx] != markerData[idx]) {
                    found = false;
                    break;
                }
            }
            if (found) {
                input.Position = lastPosition + markerLength;
                using (FileStream output = File.OpenWrite(outputFilename)) {
                    input.CopyTo(output);
                }
            }
            lastPosition = input.Position;
        }
    }
