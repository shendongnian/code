    // Initialize Connection 
            client = new SmppClient();
            properties = client.Properties;
            properties.SystemID = "BBBB";
            properties.Password = "BBBB";
            properties.Port = 1234; //IP port to use
            properties.Host = "1.2.3.4"; //SMSC host name or IP Address
            properties.SystemType = "EXT_SME"; 
            properties.DefaultServiceType = "EXT_SME";
            //Resume a lost connection after 30 seconds
            client.AutoReconnectDelay = 3000;
            TextMessage send_msg = new TextMessage();
            send_msg.DestinationAddress = mobile_number; //Receipient number
            send_msg.SourceAddress = "1234"; //Originating number
            send_msg.Text = message;
            send_msg.RegisterDeliveryNotification = true; /
            client.SendMessage(send_msg);
            general_obj.WriteLog(mobile_number +" "+message, "SendLog");
