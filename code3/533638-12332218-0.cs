        void DataReceived(int start, byte[] data)
        {
            System.IO.FileStream f = new System.IO.FileStream("file.dat", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
            f.Seek(start, System.IO.SeekOrigin.Begin);
            f.Write(data, start, data.Length);
            f.Close();
        }
