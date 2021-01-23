    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        internal sealed class Controller
        {
            public void RunForm1()
            {
                _form1 = new Form1();
                // The next line defines our response to the button being pressed in Form1
                _form1.ButtonClicked += (sender, args) => showForm2();
                Application.Run(_form1);
            }
            private void showForm2()
            {
                var form2 = new Form2();
                // The next line defines our response to the checkbox changing in Form2.
                form2.CheckBoxChanged += 
                    (sender, args) => 
                    _form1.SetLabel("Checkbox = " + ((CheckBox)sender).Checked);
                form2.ShowDialog(_form1);
            }
            private Form1 _form1 ;
        }
    }
