    using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Windows.Forms;
    
    public class HelperClass
    {
        public static void LeaveMethos(object sender, EventArgs e)
        { 
            if ((sender as TextBox).Text.Count() < (sender as TextBox).MaxLength)
                (sender as TextBox).Text = (sender as TextBox).Text.PadLeft((sender as TextBox).MaxLength, '0');
        }
    }
