    private void button1_Click(object sender, EventArgs e)
    {
       const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.
       ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\Notepad.exe");
       info.UseShellExecute = true;
       info.Verb = "runas";
       try
       {
          Process.Start(info);
       }
       catch (Win32Exception ex)
       {
          if (ex.NativeErrorCode == ERROR_CANCELLED)
             MessageBox.Show("Why you no select Yes?");
          else
             throw;
       }
    }
