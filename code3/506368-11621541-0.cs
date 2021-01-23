    static class Serializer
    {
        public static byte[] MakePacket(ScoreCard data)
        {
            MemoryStream stream = new MemoryStream();
            using (StreamWriter sw = new StreamWriter(stream)) {
                sw.Write(1); // This indicates "version one" of your data format - you can modify the code to support multiple versions by using this
                sw.Write(data.Name);
                sw.Write(data.scores.Length);
                foreach (int score in data.scores) {
                    sw.Write(score);
                }
                sw.Write(data.played.Length);
                foreach (bool played in data.played) {
                    sw.Write(played );
                }
                sw.Write(data.bonusScore);
                sw.Write(data.local);
            }
            return stream.ToArray();
        }
    
        public static ScoreCard ReadPacket(byte[] data)
        {
            ScoreCard sc = new ScoreCard();
            MemoryStream stream = new MemoryStream(data);
            using (StreamReader sr = new StreamReader(stream)) {
                int ver = sr.ReadInt32();
                switch (ver) {
                    case 1:
                        sc.name = sr.ReadString();
                        sc.scores = new int[sr.ReadInt32()];
                        for (int i = 0; i < sc.scores.Length; i++) {
                            sc.scores[i] = sr.ReadInt32();
                        }
                        sc.played = new bool[sr.ReadInt32()];
                        for (int i = 0; i < sc.scores.Length; i++) {
                            sc.played [i] = sr.ReadBool();
                        }
                        sc.BonusScore = sr.ReadInt32();
                        sc.Local = sr.ReadBool();
                        break;
                    default: 
                        throw new Exception("Unrecognized network protocol");
                }
            }
            return sc;
        }
    }
