        void t_Tick(object sender, EventArgs e)
        {
           var mavbridgeservice = new System.ServiceProcess.ServiceController("MavBridge");
            if (mavbridgeservice.Status == ServiceControllerStatus.Running)
            {
                servicestatus.Text = ("The service is running!");
            }
            else
            {
                servicestatus.Text = "The service is stopped!";
            }  
        }
