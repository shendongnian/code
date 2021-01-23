    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using log4net;
    using log4net.Config;
     
    namespace Log4Net
    {
        public partial class Form1 : Form
        {
     
            private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);  
            public Form1()
            {
                InitializeComponent();
                log4net.Config.XmlConfigurator.Configure();
            }
     
            private void button1_Click(object sender, EventArgs e)
            {
                log.Warn("Custom Warning Message");
                log.Debug("Custom Debug Message");
                log.Info("Custom Info Message");
                log.Error("Custom Error Message");
            }
     
     
        }
    }
