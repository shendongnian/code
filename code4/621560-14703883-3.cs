    public class CreateNewHighscore
    {
        public string Name { get; private set; }
        public int Punkte { get; private set; }
        public int Groesse { get; private set; }
        public int MinenAnzahl { get; private set; }
        public int Zeit { get; private set; }
        public CreateNewHighscore(string[] infos)
        {
           // check infos count
           Name = infos[1];
           Punkte = int.Parse(infos[5]) * int.Parse(infos[7]) - 
                    2 * int.Parse(infos[9]);
           Groesse = int.Parse(infos[5]);
           MinenAnzahl = int.Parse(infos[7]);
           Zeit = int.Parse(infos[9]);
       }   
