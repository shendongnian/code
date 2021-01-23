    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.ServiceModel;
    using WcfServiceLibrary1;
    namespace WindowsService1
    {
    public partial class Service1: ServiceBase
    {
        internal static ServiceHost myServiceHost = null; 
        public WCFServiceHost1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            if (myServiceHost != null)
            {
                myServiceHost.Close();
            }
            myServiceHost = new ServiceHost(typeof(Service1));
            myServiceHost.Open();
        }
        protected override void OnStop()
        {
            if (myServiceHost != null)
            {
                myServiceHost.Close();
                myServiceHost = null;
            }
        }
    }
    }
