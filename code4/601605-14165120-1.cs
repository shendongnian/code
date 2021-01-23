    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace formcomp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                CompilerParameters Params = new CompilerParameters();
                Params.GenerateExecutable = true;
                Params.ReferencedAssemblies.Add("System.dll");
                Params.ReferencedAssemblies.Add("System.Drawing.dll");
                Params.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                Params.ReferencedAssemblies.Add("System.Runtime.InteropServices.dll");
                Params.ReferencedAssemblies.Add("System.Threading.dll");
                Params.ReferencedAssemblies.Add("System.IO.dll");
                Params.OutputAssembly = "output.exe";
                Params.CompilerOptions = " /target:winexe";
                string Source = GetSource();
                CompilerResults results = new CSharpCodeProvider().CompileAssemblyFromSource(Params, Source);
                if (results.Errors.Count < 0)
                {
                    MessageBox.Show("nice");
                }
                else
                {
                    foreach (var error in results.Errors)
                    {
                        MessageBox.Show(error.ToString());
                    }
                }
            }
            private string GetSource()
            {
                string code = "using System; " + Environment.NewLine;
                code += "using System.Drawing;" + Environment.NewLine;
                code += "using System.Windows.Forms;" + Environment.NewLine;
                code += "namespace MyApp" + Environment.NewLine;
                code += "{" + Environment.NewLine;
                code += "public class Program" + Environment.NewLine;
                code += "{" + Environment.NewLine;
                code += "[STAThread]" + Environment.NewLine;
                code += "static void Main()" + Environment.NewLine;
                code += "{" + Environment.NewLine;
                code += "Application.EnableVisualStyles();" + Environment.NewLine;
                code += "Application.SetCompatibleTextRenderingDefault(false);" + Environment.NewLine;
                code += "Application.Run(new Form1());" + Environment.NewLine;
                code += "}" + Environment.NewLine;
                code += "}" + Environment.NewLine;
                code += "        public partial class Form1 : Form" + Environment.NewLine;
                code += "        {" + Environment.NewLine;
                code += "            public Form1()" + Environment.NewLine;
                code += "            {" + Environment.NewLine;
                code += "                #region AddControls" + Environment.NewLine;
                code += "                //Basic Form Seetings" + Environment.NewLine;
                code += "                this.Text = \"AppName\";" + Environment.NewLine;
                code += "                this.ControlBox = false;" + Environment.NewLine;
                code += "                this.ShowInTaskbar = false;" + Environment.NewLine;
                code += "                //Add Contidions TextBox" + Environment.NewLine;
                code += "                RichTextBox conditions = new RichTextBox();" + Environment.NewLine;
                code += "                this.Controls.Add(conditions);" + Environment.NewLine;
                code += "                conditions.Width = this.Width;" + Environment.NewLine;
                code += "                conditions.Height = this.Height / 2;" + Environment.NewLine;
                code += "                conditions.BackColor = this.BackColor;" + Environment.NewLine;
                code += "                conditions.BorderStyle = BorderStyle.None;" + Environment.NewLine;
                code += "                conditions.Text =\"Sometext\";" + Environment.NewLine;
                code += "                conditions.Font = new Font(conditions.Font.FontFamily, 8, conditions.Font.Style | FontStyle.Bold);" + Environment.NewLine;
                code += "                conditions.Location = new Point(0, 130);" + Environment.NewLine;
                code += "                conditions.Enabled = false;" + Environment.NewLine;
                code += "                this.Width += 15;" + Environment.NewLine;
                code += "                //Add Contidions TextBox" + Environment.NewLine;
                code += "                //Add CodeTextBox" + Environment.NewLine;
                code += "                TextBox codeBox = new TextBox();" + Environment.NewLine;
                code += "                this.Controls.Add(codeBox);" + Environment.NewLine;
                code += "                codeBox.Width = this.Width - 60;" + Environment.NewLine;
                code += "                codeBox.Location = new Point(20, 10);" + Environment.NewLine;
                code += "                codeBox.TextAlign = HorizontalAlignment.Center;" + Environment.NewLine;
                code += "                //Add CodeTextBox" + Environment.NewLine;
                code += "                //Add DownloadButton" + Environment.NewLine;
                code += "                Button DownloadBtn = new Button();" + Environment.NewLine;
                code += "                this.Controls.Add(DownloadBtn);" + Environment.NewLine;
                code += "                DownloadBtn.Location = new Point(19, 35);" + Environment.NewLine;
                code += "                DownloadBtn.Width = 130;" + Environment.NewLine;
                code += "                DownloadBtn.Height = 30;" + Environment.NewLine;
                code += "                DownloadBtn.Text = \"Download Code\";" + Environment.NewLine;
                code += "                Button SubmitBtn = new Button();" + Environment.NewLine;
                code += "                this.Controls.Add(SubmitBtn);" + Environment.NewLine;
                code += "                SubmitBtn.Location = new Point(this.Width - 169, 35);" + Environment.NewLine;
                code += "                SubmitBtn.Width = 130;" + Environment.NewLine;
                code += "                SubmitBtn.Height = 30;" + Environment.NewLine;
                code += "                SubmitBtn.Text = \"Submit\";" + Environment.NewLine;
                code += "                Button VerifyEmailBtn = new Button();" + Environment.NewLine;
                code += "                this.Controls.Add(VerifyEmailBtn);" + Environment.NewLine;
                code += "                VerifyEmailBtn.Location = new Point(19, 70);" + Environment.NewLine;
                code += "                VerifyEmailBtn.Width = codeBox.Width + 1;" + Environment.NewLine;
                code += "                VerifyEmailBtn.Height = 30;" + Environment.NewLine;
                code += "                VerifyEmailBtn.Text = \"Click here if you need to verify your email\";" + Environment.NewLine;
                code += "                //Add DownloadButton" + Environment.NewLine;
                code += "                #endregion" + Environment.NewLine;
                code += "            }" + Environment.NewLine;
                code += "        }" + Environment.NewLine;
                code += "    }" + Environment.NewLine;
                return code;
            }
        }
    }
