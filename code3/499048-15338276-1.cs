    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();
            app.Setup();
            Console.ReadLine();
           
        }
        public void Setup()
        {
            XMSFactoryFactory xff = XMSFactoryFactory.GetInstance(XMSC.CT_WMQ);
            IConnectionFactory cf = xff.CreateConnectionFactory();
            cf.SetStringProperty(XMSC.WMQ_HOST_NAME, "10.87.188.156(7111)");
            cf.SetIntProperty(XMSC.WMQ_PORT, 7111);
            cf.SetStringProperty(XMSC.WMQ_CHANNEL, "QMEIGS1.CRM.SVRCONN");
            cf.SetIntProperty(XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT);
            cf.SetStringProperty(XMSC.WMQ_QUEUE_MANAGER, "QMEIGS1");
            cf.SetIntProperty(XMSC.WMQ_BROKER_VERSION, XMSC.WMQ_BROKER_V1);
            IConnection conn = cf.CreateConnection();
            Console.WriteLine("connection created");
            ISession sess = conn.CreateSession(false, AcknowledgeMode.AutoAcknowledge);
            IDestination dest = sess.CreateQueue("DOX.APYMT.ESB.SSK.RPO.02");
            IMessageConsumer consumer = sess.CreateConsumer(dest);
            MessageListener ml = new MessageListener(OnMessage);
            consumer.MessageListener = ml;
            conn.Start();
            Console.WriteLine("Consumer started");
            
        }
        private void OnMessage(IMessage msg)
        {
            ITextMessage textMsg = (ITextMessage)msg;
            Console.Write("Got a message: ");
            Console.WriteLine(textMsg.Text);
        }
       
    }
