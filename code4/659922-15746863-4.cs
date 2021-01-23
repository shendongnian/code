    unsafe public static void Main(string[] args){
        Process p = new Process();
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        // set admin user and password
        p.StartInfo.UserName = "adminusername";
        char[] chArray = "adminpassword".ToCharArray();
        System.Security.SecureString str;
        fixed (char* chRef = chArray) {
            str = new System.Security.SecureString(chRef, chArray.Length);
        }
        p.StartInfo.Password = str;
        // run and redirect as usual
        p.StartInfo.FileName = utilityPath;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();
        string output = p.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        p.WaitForExit();
    }
