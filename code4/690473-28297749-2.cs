        do
        {
        // Sleep or Pause the Thread for 1 sec, if service is running too fast...
        Thread.Sleep(millisecondsTimeout: 1000);
        Guid tempGuid = ToSeqGuid();
        string newFileName = tempGuid.ToString().Split('-')[0];
        string outputFileName = appPath + "\\pdf2png\\" + fileNameithoutExtension + "-" + newFileName +
                                ".png";
        extractor.SaveCurrentImageToFile(outputFileName, ImageFormat.Png);
        // Create text file here using Tesseract
        foreach (var file in Directory.GetFiles(appPath + "\\pdf2png"))
        {
            try
            {
                var pngFileName = Path.GetFileNameWithoutExtension(file);
                string[] myArguments =
                {
                    "/C tesseract ", file,
                    " " + appPath + "\\png2text\\" + pngFileName
                }; // /C for closing process automatically whent completes
                string strParam = String.Join(" ", myArguments);
                var myCmdProcess = new Process();
                var theProcess = new ProcessStartInfo("cmd.exe", strParam)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WindowStyle = ProcessWindowStyle.Minimized
                }; // Keep the cmd.exe window minimized
                myCmdProcess.StartInfo = theProcess;
                myCmdProcess.Exited += myCmdProcess_Exited;
                myCmdProcess.Start();
                //if (process)
                {
                    /*
                    MessageBox.Show("cmd.exe process started: " + Environment.NewLine +
                                    "Process Name: " + myCmdProcess.ProcessName +
                                    Environment.NewLine + " Process Id: " + myCmdProcess.Id
                                    + Environment.NewLine + "process.Handle: " +
                                    myCmdProcess.Handle);
                    */
                    Process.EnterDebugMode();
                    //ShowWindow(hWnd: process.Handle, nCmdShow: 2);
                    /*
                    MessageBox.Show("After EnterDebugMode() cmd.exe process Exited: " +
                                    Environment.NewLine +
                                    "Process Name: " + myCmdProcess.ProcessName +
                                    Environment.NewLine + " Process Id: " + myCmdProcess.Id
                                    + Environment.NewLine + "process.Handle: " +
                                    myCmdProcess.Handle);
                    */
                    myCmdProcess.WaitForExit(60000);
                    /*
                    MessageBox.Show("After WaitForExit() cmd.exe process Exited: " +
                                    Environment.NewLine +
                                    "Process Name: " + myCmdProcess.ProcessName +
                                    Environment.NewLine + " Process Id: " + myCmdProcess.Id
                                    + Environment.NewLine + "process.Handle: " +
                                    myCmdProcess.Handle);
                    */
                    myCmdProcess.Refresh();
                    Process.LeaveDebugMode();
                    //myCmdProcess.Dispose();
                    /*
                    MessageBox.Show("After LeaveDebugMode() cmd.exe process Exited: " +
                                    Environment.NewLine);
                    */
                }
                //process.Kill();
                // Waits for the process to complete task and exites automatically
                Thread.Sleep(millisecondsTimeout: 1000);
                // This works fine in Windows 7 Environment, and not in Windows 8
                // Try following code block
                // Check, if process is not comletey exited
                if (!myCmdProcess.HasExited)
                {
                    //process.WaitForExit(2000); // Try to wait for exit 2 more seconds
                    /*
                    MessageBox.Show(" Process of cmd.exe was exited by WaitForExit(); Method " +
                                    Environment.NewLine);
                    */
                    try
                    {
                        // If not, then Kill the process
                        myCmdProcess.Kill();
                        //myCmdProcess.Dispose();
                        //if (!myCmdProcess.HasExited)
                        //{
                        //    myCmdProcess.Kill();
                        //}
                        MessageBox.Show(" Process of cmd.exe exited ( Killed ) successfully " +
                                        Environment.NewLine);
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        MessageBox.Show(
                            " Exception: System.ComponentModel.Win32Exception " +
                            ex.ErrorCode + Environment.NewLine);
                    }
                    catch (NotSupportedException notSupporEx)
                    {
                        MessageBox.Show(" Exception: NotSupportedException " +
                                        notSupporEx.Message +
                                        Environment.NewLine);
                    }
                    catch (InvalidOperationException invalidOperation)
                    {
                        MessageBox.Show(
                            " Exception: InvalidOperationException " +
                            invalidOperation.Message + Environment.NewLine);
                        foreach (
                            var textFile in Directory.GetFiles(appPath + "\\png2text", "*.txt",
                                SearchOption.AllDirectories))
                        {
                            loggingInfo += textFile +
                                           " In Reading Text from generated text file by Tesseract " +
                                           Environment.NewLine;
                            strBldr.Append(File.ReadAllText(textFile));
                        }
                        // Delete text file after reading text here
                        Directory.GetFiles(appPath + "\\pdf2png").ToList().ForEach(File.Delete);
                        Directory.GetFiles(appPath + "\\png2text").ToList().ForEach(File.Delete);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    " Cought Exception in Generating image do{...}while{...} function " +
                    Environment.NewLine + exception.Message + Environment.NewLine);
            }
        }
        // Delete png image here
        Directory.GetFiles(appPath + "\\pdf2png").ToList().ForEach(File.Delete);
        Thread.Sleep(millisecondsTimeout: 1000);
        // Read text from text file here
        foreach (var textFile in Directory.GetFiles(appPath + "\\png2text", "*.txt",
            SearchOption.AllDirectories))
        {
            loggingInfo += textFile +
                           " In Reading Text from generated text file by Tesseract " +
                           Environment.NewLine;
            strBldr.Append(File.ReadAllText(textFile));
        }
        // Delete text file after reading text here
        Directory.GetFiles(appPath + "\\png2text").ToList().ForEach(File.Delete);
    } while (extractor.GetNextImage()); // Advance image enumeration... 
