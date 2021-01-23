        private void ServiceCommunications()
        {
            var host = new ServiceHost(typeof(MainApplication));
            host.Open();
            while (keepAlive)
            {
                // Do nothing
            }
            host.Close();
        }
