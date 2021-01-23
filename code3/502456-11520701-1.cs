    using System;
    using System.Collections;
    using System.Configuration;
    using IBM.WMQ;
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Connection properties
                var properties = new Hashtable();
                properties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_CLIENT);
                properties.Add(MQC.CHANNEL_PROPERTY, "SOME.CHANNEL.TCP");
                properties.Add(MQC.HOST_NAME_PROPERTY, "12.34.56.78");
                properties.Add(MQC.PORT_PROPERTY, 1416);
                var qmgr = new MQQueueManager("MYQMGR", properties);
                Console.WriteLine("Local  : {0}", GetQueueDepth(qmgr, "FOO.LOCALQ"));
                Console.WriteLine("Report : {0}", GetQueueDepth(qmgr, "FOO.REPORTQ"));
            }
            public static int GetQueueDepth(MQQueueManager queuemgr, string queue)
            {
                return queuemgr.AccessQueue(queue,
                    MQC.MQOO_INPUT_AS_Q_DEF + 
                    MQC.MQOO_FAIL_IF_QUIESCING + 
                    MQC.MQOO_INQUIRE).CurrentDepth;
            }
        }
    }
