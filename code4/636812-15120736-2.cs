    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    using System.Reflection;
    namespace MamaProgram
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                string source =
               @"
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using MyMama = MamaProgram;              
    namespace Baby
    {
        public class Program
        {
            public WebBrowser wb = new WebBrowser();        
        
            public void navigateTo(string url)
            {
                wb.Navigated += wb_navigated;            
                wb.Navigate(url);            
            }
            public void wb_navigated(object sender, WebBrowserNavigatedEventArgs e)
            {            
                MyMama.Form1.getResult(wb.DocumentText);            
            }
        }
    }
                ";
                Dictionary<string, string> providerOptions = new Dictionary<string, string>
                    {
                        {"CompilerVersion", "v3.5"}
                    };
            
                CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);
                CompilerParameters compilerParams = new CompilerParameters
                {
                    GenerateInMemory = true,
                    GenerateExecutable = false,
                    TreatWarningsAsErrors = false                
                };
                compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
                compilerParams.ReferencedAssemblies.Add("System.Data.dll");            
                compilerParams.ReferencedAssemblies.Add(typeof(System.Linq.Enumerable).Assembly.Location); // Trick to add assembly without knowing their name            
                compilerParams.ReferencedAssemblies.Add(typeof(System.ComponentModel.Component).Assembly.Location); // Trick to add assembly without knowing their name                        
                compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, source);
                if (results.Errors.Count != 0)
                    throw new Exception("Compilation failed");
            
                object o = results.CompiledAssembly.CreateInstance("Baby.Program");
                MethodInfo mi2 = o.GetType().GetMethod("navigateTo");
                mi2.Invoke(o, new object[] { "http://www.google.com" });                        
            }
            public static void getResult(string result)
            {
                MessageBox.Show(result);
            }        
        }
    }
