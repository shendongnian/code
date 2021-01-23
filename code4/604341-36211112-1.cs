    using System;
    using System.Threading;
    using System.Collections.Generic;
    using Lidgren.Network;
    using System.Net;
    
    namespace ChatClient
    {
      class Program
      {
        static NetPeerConfiguration serverconfig;
        static NetPeerConfiguration clientconfig;
        static NetServer server;
        static NetClient client;
    
        static void Main()
        {
          NetPeerConfiguration serverconfig = new NetPeerConfiguration("chat");
          serverconfig.Port = 8081;
          serverconfig.MaximumConnections = 100;
          server = new NetServer(serverconfig);
          Thread serverthread = new Thread(StartServer);
          serverthread.Start();
    
    
    
        
    
          NetPeerConfiguration clientconfig = new NetPeerConfiguration("chat");
          clientconfig.AutoFlushSendQueue = false;
          client = new NetClient(clientconfig);
          Thread clientthread = new Thread(StartClient);
          clientthread.Start();
          AcceptConsoleInput();
    
        }
    
        static void StartServer()
        {
          server.Start();
          NetIncomingMessage message;
    
          while (true)
          {
            message = server.WaitMessage(500);
            if (message != null)
            {
              switch (message.MessageType)
              {
                case NetIncomingMessageType.DiscoveryRequest:
                  NetOutgoingMessage response = server.CreateMessage();
                  response.Write((byte)1); // Do I need to do this?
                  server.SendDiscoveryResponse(response, message.SenderEndPoint);
                  break;
                case NetIncomingMessageType.DebugMessage:
                  Console.ForegroundColor = ConsoleColor.Cyan;
                  Console.WriteLine("(Server) Debug: " + message.ReadString());
                  break;
                case NetIncomingMessageType.StatusChanged:
                  NetConnectionStatus status = (NetConnectionStatus)message.ReadByte();
    
                  string reason = message.ReadString();
                  Console.WriteLine(NetUtility.ToHexString(message.SenderConnection.RemoteUniqueIdentifier) + " " + status + ": " + reason);
    
                  if (status == NetConnectionStatus.Connected)
                    Console.WriteLine("Remote hail: " + message.SenderConnection.RemoteHailMessage.ReadString());
                  break;
                case NetIncomingMessageType.Data:
                  // incoming chat message from a client
                  string chat = message.ReadString();
    
    
                  // broadcast this to all connections, except sender
                  List<NetConnection> all = server.Connections; // get copy
                                                                //all.Remove(message.SenderConnection);
                  Console.WriteLine(all + "hello ");
                  
                  NetOutgoingMessage om = server.CreateMessage();
                  server.SendMessage(om, all, NetDeliveryMethod.ReliableOrdered, 0);
    
                  break;
                default:
                  Console.ForegroundColor = ConsoleColor.Cyan;
                  Console.WriteLine("(Server) Unrecognized message type! (" + message.MessageType + ")");
                  break;
              }
            }
            server.Recycle(message);
          }
          Thread.Sleep(1);
        }
    
        static void StartClient()
        {
          client.Start();
          client.DiscoverLocalPeers(8081);
          NetOutgoingMessage hail = client.CreateMessage("This is the hail message");
    
    
          NetIncomingMessage message;
    
          while (true)
          {
            message = client.WaitMessage(500);
            if (message != null) { 
            switch (message.MessageType)
            {
                case NetIncomingMessageType.DiscoveryResponse:
                  Console.WriteLine("(Client) Got response from server.");
                  client.Connect(message.SenderEndPoint, hail);
                  Console.WriteLine("(Client) Attempting to connect to server...");
                  break;
    
                case NetIncomingMessageType.DebugMessage:
                Console.WriteLine(message.ReadString());
                break;
              case NetIncomingMessageType.ErrorMessage:
                Console.WriteLine(message.ReadString());
                break;
              case NetIncomingMessageType.WarningMessage:
                Console.WriteLine(message.ReadString());
                break;
              case NetIncomingMessageType.VerboseDebugMessage:
                Console.WriteLine(message.ReadString());
                break;
              case NetIncomingMessageType.Data:
                string chat = message.ReadString();
                break;
              case NetIncomingMessageType.StatusChanged:
                NetConnectionStatus status = (NetConnectionStatus)message.ReadByte();
                Console.WriteLine(status.ToString());
                break;
              default:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("(Client) Unrecognized message type! (" + message.MessageType + ")");
                break;
            }
          }
            client.Recycle(message);
          }
        }
        
    
        static void AcceptConsoleInput()
        {
          string input = Console.ReadLine();
    
          if (!string.IsNullOrWhiteSpace(input))
          {
            NetOutgoingMessage om = client.CreateMessage(input);
            client.SendMessage(om, NetDeliveryMethod.ReliableSequenced);
            client.FlushSendQueue();
          }
    
          AcceptConsoleInput();
        }
      }
    }
