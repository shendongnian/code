        public static void GetQueueName()
        {
            Hashtable mqProps = new Hashtable();
            MQQueueManager qm = null;
            String strCorrelId = "00123456789";
            MQQueue importQ = null;
            Reconnect:
            try
            {
                mqProps.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
                mqProps.Add(MQC.CHANNEL_PROPERTY, "NET.CHL");
                mqProps.Add(MQC.HOST_NAME_PROPERTY, "localhost");
                mqProps.Add(MQC.PORT_PROPERTY, 2099);
                qm = new MQQueueManager("QM1", mqProps);
            }
            catch (MQException mqex)
            {
                // Handle any exception appropriately
            }
            try
            {
                importQ = qm.AccessQueue("Q1", MQC.MQOO_INPUT_SHARED | MQC.MQOO_OUTPUT | MQC.MQOO_FAIL_IF_QUIESCING);
                MQMessage mqPutMsg = new MQMessage();
                mqPutMsg.WriteString("This is an import message");
                mqPutMsg.CorrelationId = System.Text.Encoding.UTF8.GetBytes(strCorrelId);
                MQPutMessageOptions mqpmo = new MQPutMessageOptions();
                mqpmo.Options = MQC.MQPMO_NEW_CORREL_ID;
                importQ.Put(mqPutMsg,mqpmo);
                MQMessage respMsg = new MQMessage();
                MQGetMessageOptions gmo = new MQGetMessageOptions();
                gmo.WaitInterval = 3000;
                gmo.Options = MQC.MQGMO_WAIT;
                    importQ.Get(respMsg, gmo);
                }
                catch (MQException ex)
                {
                    switch(ex.ReasonCode)
                    {
                        case MQC.MQRC_CONNECTION_BROKEN:
                        case MQC.MQRC_CONNECTION_ERROR:
                        case MQC.MQRC_CONNECTION_QUIESCING:
                            {
                                try
                                {
                                    importQ.Close();
                                    qm.Disconnect();
                                }
                                catch (Exception ex1)
                                {
                                    // Ignore any exception
                                }
                                goto Reconnect;
                            }
                    }
                }
                importQ.Close();                
                qm.Disconnect();
        }
