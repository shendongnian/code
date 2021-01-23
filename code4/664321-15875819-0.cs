    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System;
    
    namespace SimpleMath.UI
    {
        class Add_operation
        {
            public string Calculate(decimal i, decimal j)
            {
                return (i + j).ToString();
            }
     
            private void btnCalculate_Click(object sender, EventArgs e)
            {
               // do some stuff here
               // or remove the method if it's empty
            }
        }
    }
