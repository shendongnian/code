    private int GetMessageCount(string queueName)
    {
        int count = 0;
        try
        {
            MSMQ.MSMQManagement mgmt = new MSMQ.MSMQManagement();
            MSMQ.MSMQOutgoingQueueManagement outgoing;
            String s = "YOURPCNAME";
            Object ss = (Object)s;
            String pathName = queueName;
            Object pn = (Object)pathName;
            String format = null;
            Object f = (Object)format;
            mgmt.Init(ref ss , ref f, ref pn);
            outgoing = (MSMQ.MSMQOutgoingQueueManagement)mgmt;
            count = outgoing.MessageCount;
            
        }
        catch (Exception ee)
        {
            MessageBox.Show(ee.ToString());
        }
        return count;
    }
