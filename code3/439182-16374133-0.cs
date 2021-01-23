        string sql = "";
        try
        {
            //Read file from C:\
            string path;
            path = Fname;
            StreamReader file = new StreamReader(path);
            string input = file.ReadToEnd();
            file.Close();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = ExeLocation;//@"C:\Program Files (x86)\MySQL\MySQL Server 5.0\bin\mysqlimport.exe";
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = false;
            psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
            Uid, Pass, Ip, DBName);
            psi.UseShellExecute = false;
            Console.WriteLine(psi);
            Process process = Process.Start(psi);
            process.StandardInput.WriteLine(input);
            process.StandardInput.Close();
            process.WaitForExit();
            process.Close();
            sql = "OK";
        }
        catch (Exception ex)
        {
            sql = ex.Message;
        }
        return sql;
    }
