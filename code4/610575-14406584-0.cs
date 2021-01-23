                // create connection
                Console.Write("Connecting to queue manager.. ");
                queueManager = new MQQueueManager(queueManagerName, properties);
                Console.WriteLine("done");
                // accessing queue
                Console.Write("Accessing queue " + queueName + ".. ");
                queue = queueManager.AccessQueue(queueName, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING);
                Console.WriteLine("done");
                // getting messages continuously
                for (int i = 1; i <= numberOfMsgs; i++)
                {
                    // creating a message object
                    message = new MQMessage();
                    try
                    {
                        queue.Get(message);
                        Console.WriteLine("Message " + i + " got = " + message.ReadString(message.MessageLength));
                        message.ClearMessage();
                    }
                    catch (MQException mqe)
                    {
                        if (mqe.ReasonCode == 2033)
                        {
                            Console.WriteLine("No message available");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("MQException caught: {0} - {1}", mqe.ReasonCode, mqe.Message);
                            break;
                        }
                    }
                }
