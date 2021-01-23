    public static int Injector(string parameter)
    {
      try
      {
        var mainForm = Application.OpenForms.OfType<Form>().FirstOrDefault(form => form.GetType().FullName.EndsWith("MainForm"));
        var builder = new StringBuilder();
        builder.AppendFormat("process: {0}\r\n\r\n", Application.ExecutablePath);
        builder.AppendFormat("type: {0}\r\n", mainForm.GetType().FullName);
        foreach (var field in mainForm.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
          builder.AppendFormat("field {0}: {1}\r\n", field.Name, field.GetValue(mainForm));
        }
        new Form()
        {
          Controls = 
          {
            new TextBox
            {
              Text = builder.ToString(),
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
