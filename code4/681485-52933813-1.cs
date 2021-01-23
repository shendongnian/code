    Process Proc = new Process();
    Proc.StartInfo.UseShellExecute = false;
    Proc.StartInfo.CreateNoWindow = true;
    Proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    Proc.StartInfo.FileName = @"qwinsta.exe";
    Proc.StartInfo.Arguments = @"console";
    Proc.StartInfo.RedirectStandardOutput = true;
    Proc.Start();
    if (!Proc.WaitForExit(2000) || Proc.ExitCode != 0)
    {
        try { Proc.Kill(); } catch { }
        return null;
    }
    string Resultado = Proc.StandardOutput.ReadToEnd();
    string[] Textos = Resultado.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    int Indice = 0;
    foreach (string TXT in Textos) { if (TXT == ">console") { break; } else Indice++; }
    return Textos[Indice + 1];
