    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Renci.SshNet;
    using Renci.SshNet.Common;
    namespace SSH2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                SSH client = new SSH("servername", "username", "password");
                MessageBox.Show(client.command("ls -la /"));
            }
        }
        public class SSH
        {
            string servername;
            int port;
            string username;
            string password;
            SshClient Server = null;
            public SSH(string servername, int port, string username, string password)
            {
                this.servername = servername;
                this.port = port;
                this.username = username;
                this.password = password;
            
                this.init();
            }
            public SSH(string servername, string username, string password)
            {
                this.servername = servername;
                this.port = 22;
                this.username = username;
                this.password = password;
                this.init();
            }
            private void init()
            {
                KeyboardInteractiveAuthenticationMethod kauth = new KeyboardInteractiveAuthenticationMethod(this.username);
                PasswordAuthenticationMethod pauth = new PasswordAuthenticationMethod(this.username, this.password);
                kauth.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>(HandleKeyEvent);
                this.Server = new SshClient(new ConnectionInfo(this.servername, this.port, this.username, pauth, kauth));
            }
            void HandleKeyEvent(Object sender, AuthenticationPromptEventArgs e)
            {
                foreach (AuthenticationPrompt prompt in e.Prompts)
                {
                    if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1)
                    {
                        prompt.Response = this.password;
                    }
                }
            }
            public string command(string cmd)
            {
                this.Server.Connect();
            
                var output = this.Server.RunCommand(cmd);
            
                this.Server.Disconnect();
            
                return output.Result;
            }
        }
    }
