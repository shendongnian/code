    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using IBM.XMS;
    namespace XMSTest
    {
        class MyXmsApp
        {
            static void Main(string[] args)
            {
                MyXmsApp app = new MyXmsApp();
                app.Setup();
                Console.ReadLine();
            }
            public void Setup()
            {
                XMSFactoryFactory xff = XMSFactoryFactory.GetInstance(XMSC.CT_WMQ);
                IConnectionFactory cf = xff.CreateConnectionFactory();
                cf.SetStringProperty(XMSC.WMQ_HOST_NAME, "localhost");
                cf.SetIntProperty(XMSC.WMQ_PORT, 1414);
                cf.SetStringProperty(XMSC.WMQ_CHANNEL, "CLIENT");
                cf.SetIntProperty(XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT);
                cf.SetStringProperty(XMSC.WMQ_QUEUE_MANAGER, "QM_LOCAL");
                cf.SetIntProperty(XMSC.WMQ_BROKER_VERSION, XMSC.WMQ_BROKER_V1);
                IConnection conn = cf.CreateConnection();
                Console.WriteLine("connection created");
                ISession sess = conn.CreateSession(false, AcknowledgeMode.AutoAcknowledge);
                IDestination dest = sess.CreateQueue("queue://q");
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
    }
