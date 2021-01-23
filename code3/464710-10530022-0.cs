    System.Text.Encoding GreekEncoding = System.Text.Encoding.GetEncoding(1253);
    System.IO.StreamReader sr = new StreamReader(@"c:\test.txt", GreekEncoding);
    System.Diagnostics.Debug.WriteLine(sr.ReadLine());
    sr.Close();
    sr.Dispose();
