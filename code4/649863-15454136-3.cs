    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            /// <summary>
            /// Der Haupteinstiegspunkt für die Anwendung.
            /// </summary>
            [STAThread]
            static void Main()
            {
                var yourchild = new ChildClass();
                yourchild.childProp1 = 222;
                yourchild.childProp2 = "Childstring";
                yourchild.childProp6 = new ChildClass() { childProp2="ChildChild" };
    
                var yourObject = new myClass(1,"mystring",5.5,1.3f);
                yourObject.prop6 = yourchild;
    
    
    
                //First Step
                // create a XAML string
                string stCopie = System.Windows.Markup.XamlWriter.Save(yourObject);
    
                //Secound Step
                // convert him back to an Object of YourTyp
                var Copie = System.Windows.Markup.XamlReader.Load(System.Xml.XmlReader.Create(new System.IO.StringReader(stCopie))) as myClass;
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
