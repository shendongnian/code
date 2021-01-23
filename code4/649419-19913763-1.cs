     var messageBodyType = Type.GetType(receivedMessage.Properties["messageType"].ToString());
                    if (messageBodyType == null)
                    {
                        //Should never get here as a messagebodytype should
                        //always be set BEFORE putting the message on the queue
                        Trace.TraceError("Message does not have a messagebodytype" +
                                         " specified, message {0}", receivedMessage.MessageId);
                        receivedMessage.DeadLetter();
                    }
                    //read body only if event handler hooked
                        var method = typeof(BrokeredMessage).GetMethod("GetBody", new Type[] { });
                        var generic = method.MakeGenericMethod(messageBodyType);
                        try
                        {
                            var messageBody = generic.Invoke(receivedMessage, null);
                             DoSomethingWithYourData();
                            receivedMessage.Complete();
                        }
                        catch (Exception e)
                        {
                            Debug.Write("Can not handle message. Abandoning.");
                            receivedMessage.Abandon();
                        }
                    }
