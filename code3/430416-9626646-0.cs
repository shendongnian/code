    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        class Class1
        {
            public void someMethod()
            {
                TextBox t = Application.OpenForms["Form1"].Controls["textBox1"] as TextBox;
                Debug.WriteLine(t.Text + "what?");
            }
        }
    }
