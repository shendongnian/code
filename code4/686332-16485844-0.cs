        private void Grouping(ref List<string> results)
        {
            Random r=new Random();
            int index = 0;
            for (int i = players.Count /2; i > 0;i--)
            {
                index++;
                back:
                int rand1 = r.Next(players.Count);
                int rand2 = r.Next(players.Count);
                if (rand1 == rand2)
                {
                    // Random numbers are same :(
                    goto back; // I know - it'll be slowly :(
                }
                results.Add(index + ".: " + players[rand1] + " - " + players[rand2]);
                players.Remove(players[rand1]);
                players.Remove(players[rand2]);
            }
        }
