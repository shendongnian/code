    // form1.cs
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.ServiceModel;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                ChannelFactory<IShout> channel = new ChannelFactory<IShout>(new BasicHttpBinding(), "http://localhost:9189");
                IShout shout = channel.CreateChannel();
                String reply = shout.Broadcast("Test"); 
            }
        }
    }
    // and Program.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.ServiceModel;
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                ServiceHost s = new ServiceHost(typeof(eveShout));
                s.AddServiceEndpoint(typeof(IShout), new BasicHttpBinding(), "http://localhost:9189");
                s.Open(); 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
        public class eveShout : IShout
        {
            public String Broadcast(String message)
            {
                return message + " reply";
            }
        } 
        [ServiceContract]
        public interface IShout
        {
            [OperationContract]
            String Broadcast(String message);
        } 
    }
