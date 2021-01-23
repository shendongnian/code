        /// <summary>
        /// This will attempt to open a service to listen for message requests. 
        /// If the service is already in use it means that another instance of this WPF application is running.
        /// </summary>
        /// <returns>false if the service is already in use by another WPF instance and cannot be opened;  true if the service sucessfully opened</returns>
        private bool TryOpeningTheMessageListener()
        {
            try
            {
                NetNamedPipeBinding b = new NetNamedPipeBinding();
                sh = new ServiceHost(this);
                sh.AddServiceEndpoint(typeof(IOpenForm), b, SERVICE_URI);
                sh.Open();
                return true;
            }
            catch (AddressAlreadyInUseException)
            {
                return false;
            }
        }
        private void SendExistingInstanceOpenMessage(int formInstanceId, int formTemplateId, bool isReadOnly, DateTime generatedDate, string hash)
        {
            try
            {
                NetNamedPipeBinding b = new NetNamedPipeBinding();
                var channel = ChannelFactory<IOpenForm>.CreateChannel(b, new EndpointAddress(SERVICE_URI));
                channel.OpenForm(formInstanceId, formTemplateId, isReadOnly, generatedDate, hash);
                (channel as IChannel).Close();
            }
            catch
            {
                MessageBox.Show("For some strange reason we couldnt talk to the open instance of the application");
            }
        }
