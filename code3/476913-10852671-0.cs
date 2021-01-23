    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.IO;
    
    namespace LolBot
    {
        internal struct IRCConfig
        {
            public string server;
            public int port;
            public string nick;
            public string name;
    
        }
    
        internal class IRCBot : IDisposable
        {
            private TcpClient IRCConnection = null;
            private IRCConfig config;
            private NetworkStream ns = null;
            private StreamReader sr = null;
            private StreamWriter sw = null;
    
            public IRCBot(IRCConfig config)
            {
                this.config = config;
            }
    
            public void Connect()
            {
                try
                {
                    IRCConnection = new TcpClient(config.server, config.port);
                }
                catch
                {
                    Console.WriteLine("Connection Error");
                    throw;
                }
    
                try
                {
                    ns = IRCConnection.GetStream();
                    sr = new StreamReader(ns);
                    sw = new StreamWriter(ns);
                    sendData("USER", config.nick + config.name);
                    sendData("NICK", config.nick);
                }
                catch
                {
                    Console.WriteLine("Communication error");
                    throw;
                }
            }
    
            public void sendData(string cmd, string param)
            {
                if (param == null)
                {
                    sw.WriteLine(cmd);
                    sw.Flush();
                    Console.WriteLine(cmd);
                }
                else
                {
                    sw.WriteLine(cmd + " " + param);
                    sw.Flush();
                    Console.WriteLine(cmd + " " + param);
                }
            }
    
            public void IRCWork()
            {
                string[] ex;
                string data;
                bool shouldRun = true;
                while (shouldRun)
                {
                    data = sr.ReadLine();
                    Console.WriteLine(data);
                    char[] charSeparator = new char[] {' '};
                    ex = data.Split(charSeparator, 5);
    
                    if (ex[0] == "PING")
                    {
                        sendData("PONG", ex[1]);
                    }
    
                    if (ex.Length > 4) //is the command received long enough to be a bot command?
                    {
                        string command = ex[3]; //grab the command sent
    
                        switch (command)
                        {
                            case ":!join":
                                sendData("JOIN", ex[4]);
                                    //if the command is !join send the "JOIN" command to the server with the parameters set by the user
                                break;
                            case ":!say":
                                sendData("PRIVMSG", ex[2] + " " + ex[4]);
                                    //if the command is !say, send a message to the chan (ex[2]) followed by the actual message (ex[4]).
                                break;
                            case ":!quit":
                                sendData("QUIT", ex[4]);
                                    //if the command is quit, send the QUIT command to the server with a quit message
                                shouldRun = false;
                                    //turn shouldRun to false - the server will stop sending us data so trying to read it will not work and result in an error. This stops the loop from running and we will close off the connections properly
                                break;
                        }
                    }
                }
            }
    
            public void Dispose()
            {
                if (sr != null)
                    sr.Close();
                if (sw != null)
                    sw.Close();
                if (ns != null)
                    ns.Close();
                if (IRCConnection != null)
                    IRCConnection.Close();
            }
        }
    
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                IRCConfig conf = new IRCConfig();
                conf.name = "LolBot";
                conf.nick = "LolBot";
                conf.port = 6667;
                conf.server = "irc.strictfp.com";
                using (var bot = new IRCBot(conf))
                {
                    bot.Connect();
                    bot.IRCWork();
                }
                Console.WriteLine("Bot quit/crashed");
                Console.ReadLine();
            }
        }
    }
