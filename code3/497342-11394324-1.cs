    Process bf2 = new Process();
    bf2.StartInfo.FileName = @"C:\Program Files\EA Games\Battlefield 2\BF2.exe";
    bf2.StartInfo.Arguments = "+debugOutput 1";
    bf2.StartInfo.UseShellExecute = false;
    bf2.StartInfo.RedirectStandardOutput = true;
    bf2.StartInfo.RedirectStandardError = true;
    bf2.Start();    
    
    Console.WriteLine(bf2.StandardOutput.ReadToEnd());
    Console.WriteLine(bf2.StandardError.ReadToEnd());
