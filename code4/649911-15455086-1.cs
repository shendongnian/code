    static void Main(string[] args)
            {
                ProcessStartInfo prf = new ProcessStartInfo("ConsoleApplication1.exe");
                prf.UseShellExecute = true;
                prf.Arguments = "-l http://test.tes1:testa@testb.testing.com:3333/ -k testing TYPE=0 USER=1 COUNT=10";
                Process.Start(prf);
            }
