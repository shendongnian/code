    public class Derp
    {
        public static MemoryStream GeneratePdf(MemoryStream pdf)
        {
	        using (StreamReader Html = new StreamReader(@"Z:\HTMLPage.htm"))
	        {
                Process p;
                StreamWriter stdin;
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = @"C:\wkhtmltopdf\wkhtmltopdf.exe";
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.Arguments = "-q -n --disable-smart-shrinking " + " - -";
                p = Process.Start(psi);
                try
                {
                    stdin = p.StandardInput;
                    stdin.AutoFlush = true;
                    stdin.Write(Html.ReadToEnd());
                    stdin.Dispose();
                    CopyStream(p.StandardOutput.BaseStream, pdf);
                    p.StandardOutput.Close();
                    pdf.Position = 0;
                    p.WaitForExit(10000);
                    return pdf;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    p.Dispose();
                }
            }
        }
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }
    }
