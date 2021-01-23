    System.Diagnostics.Process p = new System.Diagnostics.Process();
    p.StartInfo.FileName = "ModelExporter.exe";
    p.StartInfo.RedirectStandardOutput = true;
    p.StartInfo.RedirectStandardInput = true;
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.CreateNoWindow = true;
    p.Start();
    StreamReader myStreamReader = p.StandardOutput;
    // Reads a single line of the programs output.
    string myString = myStreamReader.ReadLine(); 
    // This would print the string to the DOS Console for the sake of an example.
    // You could easily set a textbox control to this string instead...
    Console.WriteLine(myString);
    p.Close();
