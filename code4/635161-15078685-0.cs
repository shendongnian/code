        void PutMessages()
        {
            try
            {
                // mq properties
                properties = new Hashtable();
                properties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
                properties.Add(MQC.HOST_NAME_PROPERTY, hostName);
                properties.Add(MQC.PORT_PROPERTY, port);
                properties.Add(MQC.CHANNEL_PROPERTY, channelName);
                // display all details
                Console.WriteLine("MQ Parameters");
                Console.WriteLine("1) queueName = " + queueName);
                Console.WriteLine("2) host = " + hostName);
                Console.WriteLine("3) port = " + port);
                Console.WriteLine("4) channel = " + channelName);
                Console.WriteLine("5) numberOfMsgs = " + numberOfMsgs);
                Console.WriteLine("");
                // create connection
                Console.Write("Connecting to queue manager.. ");
                queueManager = new MQQueueManager(queueManagerName, properties);
                Console.WriteLine("done");
                // accessing queue
                Console.Write("Accessing queue " + queueName + ".. ");
                queue = queueManager.AccessQueue(queueName, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING);
                Console.WriteLine("done");
                // creating a message object
                message = new MQMessage();
                message.WriteString(messageString);
                
                // putting messages continuously
                for (int i = 1; i <= numberOfMsgs; i++)
                {
                    Console.Write("Message " + i + " <" + messageString + ">.. ");
                    queue.Put(message);
                    Console.WriteLine("put");
                }
                // closing queue
                Console.Write("Closing queue.. ");
                queue.Close();
                Console.WriteLine("done");
                // disconnecting queue manager
                Console.Write("Disconnecting queue manager.. ");
                queueManager.Disconnect();
                Console.WriteLine("done");
            }
            catch (MQException mqe)
            {
                Console.WriteLine("");
                Console.WriteLine("MQException caught: {0} - {1}", mqe.ReasonCode, mqe.Message);
                Console.WriteLine(mqe.StackTrace);
            }
        }
