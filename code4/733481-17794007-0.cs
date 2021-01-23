            ServiceController sc = new ServiceController("wuauserv");
            try
            {
                if (sc != null && sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Stop();
                }
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
                sc.Close();
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);
            }
