    internal class Program
    {
    
        // declare m as field at class level
        private static IBattleNET m;
    
        private static  void Main(string[] args)
        {
            ....
        }
        public static void startmessages()
        {
           BattlEyeLoginCredentials loginCredentials = GetLoginCredentials();
            
            // JUST SET THE VALUE HERE
            m = new BattlEyeClient(loginCredentials);
            m.MessageReceivedEvent += DumpMessage;
            m.DisconnectEvent += Disconnected;
            m.ReconnectOnPacketLoss(true);
            m.Connect();
    
            IConfigSource messagesource = new IniConfigSource("messages/servermessages.ini");
    
            int messagewait = messagesource.Configs["timesettings"].GetInt("delay");
            string[] messages = messagesource.Configs["rconmessages"].Get("messages1").Split('|');
        //    for (;;)
          //  {
    
                foreach (string message in messages)
                {
                    Console.WriteLine(message);
                     m.SendCommandPacket(EBattlEyeCommand.Say,message);
                     System.Threading.Thread.Sleep(messagewait * 60 * 1000); 
    
                }
         //   }
    
        }
