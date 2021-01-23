            try
            {
                importQ = qm.AccessQueue("Q2", MQC.MQOO_INPUT_SHARED | MQC.MQOO_OUTPUT | MQC.MQOO_FAIL_IF_QUIESCING);
                // Put one message. MQ generates correlid
                MQMessage mqPutMsg = new MQMessage();
                mqPutMsg.WriteString("This is the first message with no app specified correl id");
                importQ.Put(mqPutMsg);
                // Put another messages but with application specified correlation id
                mqPutMsg = new MQMessage();
                mqPutMsg.WriteString("This is the first message with application specified correl id");
                mqPutMsg.CorrelationId = System.Text.Encoding.UTF8.GetBytes(strCorrelId);
                MQPutMessageOptions mqpmo = new MQPutMessageOptions();
                importQ.Put(mqPutMsg,mqpmo);
                mqPutMsg = new MQMessage();
                // Put another message with MQ generating correlation id
                mqPutMsg.WriteString("This is the second message with no app specified correl id");
                importQ.Put(mqPutMsg);
                // Get only the message that matches the correl id
                MQMessage respMsg = new MQMessage();
                respMsg.CorrelationId = System.Text.Encoding.UTF8.GetBytes(strCorrelId);
                MQGetMessageOptions gmo = new MQGetMessageOptions();
                gmo.WaitInterval = 3000;
                gmo.Options = MQC.MQGMO_WAIT;
                gmo.MatchOptions = MQC.MQMO_MATCH_CORREL_ID;
                importQ.Get(respMsg, gmo);
                Console.WriteLine(respMsg.ReadString(respMsg.MessageLength));
            }
