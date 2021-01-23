            StreamWriter sw = null;
            bool endFlag = false;
            bool startFlag = false;
            sw = File.AppendText(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\file1.txt");
            foreach (string lineOf in errorReportContent)
            {
                if (lineOf.Contains("Report Of Conditionals Mismatch"))
                {
                    startFlag = true;
                }
                if (lineOf.Contains("End Of Conditionals Mismatch Report"))
                {
                    endFlag = true;
                }
                if (startFlag == true && endFlag != true)
                {
                    sw.WriteLine(lineOf);
                }
            }
            sw.Close();
            System.Diagnostics.Process.Start(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\file1.txt");
