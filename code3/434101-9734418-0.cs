        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Windows.Forms;
    
        namespace WindowsFormsApplication1
        {
            static class Program
            {
             
    
       /// <summary>
            /// The main entry point for the application.
            /// </summary>
            /// 
    
            //Declare a static form that will accesible trhought the appication
            //create form called frmMain form or any other name
            //
            public static frmMain MainForm { get; private set; }
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //comment out default application run
                //Application.Run(new MainForm());
    
                //create a new instance of your frmMain form
                //inside your main form add a tree view
                //Loacte this file "frmMain.Designer.cs"
                //Change treeView1 from private to public
                //  public System.Windows.Forms.TreeView treeView1;
                MainForm = new frmMain();
    
                //before I show my form I'll change docking of my tree  view from myClass
                MyClass mine = new MyClass();  //done
    
                MainForm.ShowDialog();
    
            }
    
           
        }
    
        public class MyClass
        {        
            public MyClass()
            {
                Program.MainForm.treeView1.Dock = DockStyle.Fill;
            }
            
        }
    }
