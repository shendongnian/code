    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace FallingFlowers//Falling Flowers is the name of my project
    {
    public static class IdentifyControl
    {
        public static List<Control> findControls(Control c)
        {
            List<Control> list = new List<Control>();
            foreach (Control control in c.Controls)
                list.Add(control);
            return list;
        }
    }
    }
