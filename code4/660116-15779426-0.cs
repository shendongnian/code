        public static void preserveCorreLid()
        {
            Hashtable mqProps = new Hashtable();
            MQQueueManager qm = null;
            String strCorrelId = "00123456789";
            try
            {
                mqProps.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
                mqProps.Add(MQC.CHANNEL_PROPERTY, "NET.CLIENT.CHL");
                mqProps.Add(MQC.HOST_NAME_PROPERTY, "localhost");
                mqProps.Add(MQC.PORT_PROPERTY, 2099);
                qm = new MQQueueManager("QM", mqProps);
               
                MQQueue importQ = qm.AccessQueue("IMPORTQ", MQC.MQOO_INPUT_SHARED |MQC.MQOO_OUTPUT | MQC.MQOO_FAIL_IF_QUIESCING );
                MQMessage mqPutMsg = new MQMessage();
                mqPutMsg.WriteString("This is an import message");
                mqPutMsg.CorrelationId = System.Text.Encoding.UTF8.GetBytes(strCorrelId);
                MQPutMessageOptions mqpmo = new MQPutMessageOptions();
                importQ.Put(mqPutMsg,mqpmo);
                MQMessage respMsg = new MQMessage();
                MQGetMessageOptions gmo = new MQGetMessageOptions();
                gmo.WaitInterval = 3000;
                gmo.Options = MQC.MQGMO_WAIT;
                try
                {
                    importQ.Get(respMsg, gmo);
                }
                catch (MQException ex)
                {
                    Console.Write(ex);
                 
                    Console.WriteLine("Queue Name : " + importQ.Name + ":");
                }
                importQ.Close();
                
                MQQueue exportQ = qm.AccessQueue("EXPORTQ", MQC.MQOO_OUTPUT | MQC.MQOO_FAIL_IF_QUIESCING);
                exportQ.Put(respMsg);
                exportQ.Close();
                qm.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
