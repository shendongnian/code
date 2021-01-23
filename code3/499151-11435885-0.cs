    var sw1 = new Stopwatch();
    Console.WriteLine("Test Writing many arrays");
    var data = new byte[1073741824];
    for (var i = 0; i < 1073741824; i++)
        data[i] = (byte)(i % 255);
    var file = new FileStream("c:\\temp\\__test1.txt", FileMode.Create);
    sw1.Restart();
    for (int i = 0; i < 1024; i++)
        file.Write(data, i*1024, 1048576);
    file.Close();
    sw1.Stop();
    var s1 = sw1.Elapsed;
    Console.WriteLine(s1.TotalMilliseconds);
    Console.WriteLine("Test Writing big array");
    var file2 = new FileStream("c:\\temp\\__test2.txt", FileMode.Create);
    sw1.Restart();
    file2.Write(data, 0, 1073741824);
    file2.Close();
    sw1.Stop();
    s1 = sw1.Elapsed;
    Console.WriteLine(s1.TotalMilliseconds);
