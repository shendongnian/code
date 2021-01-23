            string Path = @"z:\tools\gnuplot\bin\gnuplot.exe";
            Process GnuplotProcess = new Process();
            GnuplotProcess.StartInfo.FileName = Path;
            GnuplotProcess.StartInfo.UseShellExecute = false;
            GnuplotProcess.StartInfo.RedirectStandardInput = true;
            GnuplotProcess.StartInfo.RedirectStandardOutput = true;
            GnuplotProcess.Start();
            StreamWriter SW = GnuplotProcess.StandardInput;
            StreamReader SR = GnuplotProcess.StandardOutput;
            SW.WriteLine("plot f(x) = sin(x*a), a = .2, f(x), a = .4, f(x)");
            SW.WriteLine("exit");
            string output = SR.ReadToEnd();
            Console.WriteLine("**->" + output);
            GnuplotProcess.Close();
        
