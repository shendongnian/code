    using System;
    using System.Windows.Forms;
    public class Program {
        static void Main() {
            Application.EnableVisualStyles();
            using (var form = new Form()) {
                Application.Run(form);
            }
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(assembly.GetName().Name);
        }
    }
