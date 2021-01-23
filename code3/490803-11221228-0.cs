        private void HandleIncomePlayers()
        {
            Console.Out.WriteLine("Players income handler started.");
            MemoryStream ms;
            while (true)
            {
                ms = new MemoryStream(); //here
                byte[] data = playersData.Receive(ref playersEP);
                ms.Write(data, 0, data.Length); 
                ms.Position = 0;
                Unit player = null; 
                player = bf.Deserialize(ms) as Unit;
                Console.Out.WriteLine(player.name + " " + player.position.X + " " + player.position.Y);
                ms.Dispose(); //and here
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i] != null && player.ID == players[i].ID)
                    {
                        players[i] = player;
                        break;
                    }
                }
            }
        }
