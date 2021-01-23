    using System;
    using System.Windows.Forms;
    
    namespace TestApp
    {
      static class Program
      {
        [STAThread]
        static void Main()
        {
          try
          {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
          }
          catch (Exception exception)
          {
            MessageBox.Show(
              exception.Message +
              exception.StackTrace,
              "Error",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
          }
        }
      }
    }
