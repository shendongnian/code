    using System;
    using System.Diagnostics;
    using Microsoft.AspNet.SignalR;
    namespace MyWebApplication
    {
        public partial class Test : System.Web.UI.Page
        {
            Chat chat = new Chat();
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            void MyProcess_Exited(object sender, EventArgs e)
            {
                chat.Send("process exited");
            }
            protected void button_Click(object sender, EventArgs e)
            {
                Process MyProcess = new Process();
                MyProcess.StartInfo = new ProcessStartInfo("notepad.exe");
                MyProcess.EnableRaisingEvents = true;
                MyProcess.Exited += MyProcess_Exited;
                MyProcess.Start();
                chat.Send("process started");
            }
        }
    }
