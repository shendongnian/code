        private void OnException(Exception ex)
        {
            XMSException xmsex = (XMSException)ex;
            Console.WriteLine("Got exception");
            // Check the error code.
            if (xmsex.ErrorCode == "XMSWMQ1107")
            {
                Console.WriteLine("This is a connection broken error");
                stopProcessing = true; // This is a class member variable
            }
        }
