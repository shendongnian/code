        public static ServiceController GetService(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            return services.FirstOrDefault(_ => Contracts.Extensions.CompareStrings(_.ServiceName, serviceName));
        }
        public static bool IsServiceRunning(string serviceName)
        {
            ServiceControllerStatus status;
            uint counter = 0;
            do
            {
                ServiceController service = GetService(serviceName);
                if (service == null)
                {
                    return false;
                }
                Thread.Sleep(100);
                status = service.Status;
            } while (!(status == ServiceControllerStatus.Stopped ||
                       status == ServiceControllerStatus.Running) &&
                     (++counter < 30));
            return status == ServiceControllerStatus.Running;
        }
        public static bool IsServiceInstalled(string serviceName)
        {
            return GetService(serviceName) != null;
        }
        public static void StartService(string serviceName)
        {
            ServiceController controller = GetService(serviceName);
            if (controller == null)
            {
                return;
            }
            controller.Start();
            controller.WaitForStatus(ServiceControllerStatus.Running);
        }
        public static void StopService(string serviceName)
        {
            ServiceController controller = GetService(serviceName);
            if (controller == null)
            {
                return;
            }
            controller.Stop();
            controller.WaitForStatus(ServiceControllerStatus.Stopped);
        }
