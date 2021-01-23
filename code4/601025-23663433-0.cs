            MSMQ.MSMQApplication q = new MSMQ.MSMQApplication();
            object obj = q.ActiveQueues;
            foreach (object oFormat in (object[])q.ActiveQueues)
            {
                object oMissing = Type.Missing;
                object oMachine = System.Environment.MachineName;
                MSMQ.MSMQManagement qMgmt = new MSMQ.MSMQManagement();
                object oFormatName = oFormat; // oFormat is read only and we need to use ref
                qMgmt.Init(ref oMachine, ref oMissing, ref oFormatName);
                outPlace.Text += string.Format("{0} has {1} messages queued \n", oFormatName.ToString(), qMgmt.MessageCount.ToString());
            }
            foreach (object oFormat in (object[])q.PrivateQueues)
            {
                object oMissing = Type.Missing;
                object oMachine = System.Environment.MachineName;
                MSMQ.MSMQManagement qMgmt = new MSMQ.MSMQManagement();
                queue = new MessageQueue(oFormat.ToString());
                object oFormatName = queue.FormatName; // oFormat is read only and we need to use ref
                TimeSpan timeout=new TimeSpan(2);
               try
               {
                    Message msg = queue.Peek(timeout);
                }
                catch
                {// being lazy and catching everything for this example
                }
                qMgmt.Init(ref oMachine, ref oMissing, ref oFormatName);
                  outPlace.Text += string.Format("{0}  {1} {2}\n", oFormat.ToString(), queue.FormatName.ToString(), qMgmt.MessageCount.ToString());
            }
        }
