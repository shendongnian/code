    ProcessStartInfo psi = new ProcessStartInfo("app.exe");
    psi.RedirectStandardOutput = true;
    psi.WindowStyle = ProcessWindowStyle.Hidden;
    psi.UseShellExecute = false;
    Process app = Process.Start(psi);
    StreamReader reader = app.StandardOutput;
    do
    {
       string line = "{ \"message\": \"" + reader.ReadLine() + "\" }";
       HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/results/:" + runId + "/logs");
       request.ContentType = "text/json";
       request.Method = "POST";
       using (TextWriter tw = new StreamWriter(request.GetRequestStream()))
       {
           tw.WriteLine(line);
       }
       
    }while(!reader.EndOfStream);
    app.WaitForExit();
