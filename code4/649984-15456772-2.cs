    class MyForm // :Form
    {
        IDataTransferManager dataManager;
        public MyForm()
        {   // here, usually an instance will be passed in, 
            // so there's only one instance throughout the application.
            // let's new up an instance for explanation purposes.
            dataManager = new TcpConnection();
            dataManager.DataActivityStateChange += (state) => 
            {
                // NOTE: if you don't like inline, 
                // you can point this labda to a method.
                
                switch (state)
                {
                    case ActivityState.Sending:
                        // change the image to the spinning toilet ball
                        break;
                    case ActivityState.Receiving:
                        // change the image to the spinning toilet ball, but reverse :P
                        break;
                    case ActivityState.Idle:
                        // hide it ?
                        break;
                }
            };
        }
    }
