    public static int Injector(string parameter)
    {
      try
      {
        var text = 
          Application.ExecutablePath + "\r\n" + 
          "Forms:" + "\r\n" + 
          string.Join("\r\n", Application.OpenForms.OfType<Form>().Select(form => form.Text).ToArray());
        new Form()
        {
          Controls = 
          {
            new TextBox
            {
              Text = text,
              Multiline = true,
              Dock = DockStyle.Fill
            }
          }
        }
        .ShowDialog();
      }
      catch (Exception exc)
      {
        MessageBox.Show(exc.ToString());
      }
      return 0;
      
    }
    static void Main(string[] args)
    {
      var process = System.Diagnostics.Process.GetProcessesByName("PaintDotNet").FirstOrDefault();
      var processHandle = OpenProcess(ProcessAccessFlags.All, false, process.Id);
      var proxyPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "NInjector.dll");
      var pathBytes = System.Text.Encoding.ASCII.GetBytes(proxyPath);
      var remoteBuffer = VirtualAllocEx(processHandle, IntPtr.Zero, (uint)pathBytes.Length, AllocationType.Commit, MemoryProtection.ReadWrite);
      WriteProcessMemory(process.Handle, remoteBuffer, pathBytes, (uint)pathBytes.Length, IntPtr.Zero);
      
      var remoteThread = CreateRemoteThread(processHandle, IntPtr.Zero, 0, GetProcAddress(GetModuleHandle("kernel32"), "LoadLibraryA") , remoteBuffer, 0, IntPtr.Zero);
      WaitForSingleObject(remoteThread, unchecked((uint)-1)); 
      CloseHandle(remoteThread);
    }
