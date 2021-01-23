    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using aktos_dcs_cs;
    
    namespace pinger
    {
        class Pinger : Actor
        {
            public void handle_PingMessage(Dictionary<string, object> msg)
            {
                Console.WriteLine("Pinger handled PingMessage: {0} ", msg["text"]);
    
                string msg_ser = @"
                        {""PongMessage"": 
                            {""text"": ""this is proper message from csharp implementation""}
                        }
                    ";
                System.Threading.Thread.Sleep(2000);
                send(msg_ser);
            }
            
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                Pinger x = new Pinger(); 
                Actor.wait_all(); 
            }
        }
    }
