    string inputFilename = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
    string outputFilename = inputFilename + ".secret";
    string magic = "magic".ToUpper();
    byte[] data = File.ReadAllBytes(inputFilename);
    byte[] magicData = Encoding.ASCII.GetBytes(magic);
    for (int idx = magicData.Length - 1; idx < data.Length; idx++) {
        bool found = true;
        for (int magicIdx = 0; magicIdx < magicData.Length; magicIdx++) {
            if (data[idx - magicData.Length + 1 + magicIdx] != magicData[magicIdx]) {
                found = false;
                break;
            }
        }
        if (found) {
            using (FileStream output = new FileStream(outputFilename, FileMode.Create)) {
                output.Write(data, idx + 1, data.Length - idx - 1);
            }
        }
    }
