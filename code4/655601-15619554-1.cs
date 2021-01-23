    public class Player
    {
         public Player(){}
         public Player(string name, int score)
         {
             m_name = name;
             m_score = score;
         }
         public Player(Player p)
         {
             m_name = p.Name;
             m_score = p.Score;
         }
         public string Name
         {
             get{return m_name;}
         }
         public int Score
         {
             get{return m_score;}
         }
         private string m_name
         private int m_score
    }
    Player[] players = new Player[MAX];
    static void BubbleSort(Player[] players)
    {
        for (int j = 0; j < players.Length -1; j++)
        {
            for (int i = 0; i < players.Length - 1; i++)
            {
                if (players[i].Score > players[i + 1].Score)
                {
                    Swap(ref players[i], ref players[i + 1]);
                }
            }
        }
        foreach (Player a in players)
            Console.WriteLine("{0}", a.Score);
        Console.ReadLine();
    }
       static void Swap(ref Player a, ref Player b)
        {
            Player temp = a;
            a = b;
            b = temp;
        }
