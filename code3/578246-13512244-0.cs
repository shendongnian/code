    using System;
    using System.Diagnostics;
    namespace Lynx.Dumper
    {
      public class Dampler
      {
          public void fdksfjh()
          {
              var url = "http://www.google.com";
              var p = new Process();
              p.StartInfo = new ProcessStartInfo("c:/tools/lynx_w32/lynx.exe", "-dump -nolist " + url)
              {
                  WorkingDirectory = "c:/tools/lynx_w32/",
                  UseShellExecute = false,
                  RedirectStandardOutput = true,
                  RedirectStandardError = true,
                  WindowStyle = ProcessWindowStyle.Hidden,
                  CreateNoWindow = true
              };
              p.Start();
              p.WaitForExit();
              //grab the text rendered by Lynx
              var text = p.StandardOutput.ReadToEnd();
              Console.WriteLine(text);
          }
      }
    }
