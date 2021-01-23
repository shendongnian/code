    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Tirage.MainStand
    {
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PublicClass.Class.RunAlready RunAPP = new PublicClass.Class.RunAlready();
            string outApp = RunAPP.processIsRunning("Tirage.MainStand");
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainStand_FrmLogin fLogin = new MainStand_FrmLogin();
            if (outApp.Length == 0)
            {
                
                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainStand_masterFrm());
                 
                }
            }
            else MessageBox.Show( "Instance already running");
          }
        }
     }
