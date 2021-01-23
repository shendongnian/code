    Sub Form1_Load(s As Object, e As EventArgs)
      Using sw As New IO.StreamWriter(IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "maincode.txt"))
        sw.WriteLine("00000012{0:yyyyMMdd}{1}{0:HHmmss}", Now,
                     If((New Random).Next(0, 2) = 0, "0010", "0054"))
      End Using
    End Sub
