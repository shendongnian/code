    public class Score
    {
        public string user { get; set; }
        public string number { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var json = "[{\"user\":\"27FFBADD7284E5CB98EAC45559589E28FDDDC3AD\",\"number\":\"62827\"},{\"user\":\"27FFBADD7284E5CB98EAC45559589E28FDDDC3AD\",\"number\":\"30460\"}, {\"user\":\"0D27D44D40C5185423078B3C93B3E6B596AD21A0\",\"number\":\"25143\"}, {\"user\":\"0D27D44D40C5185423078B3C93B3E6B596AD21A0\",\"number\":\"22776\"}, {\"user\":\"27FFBADD7284E5CB98EAC45559589E28FDDDC3AD\",\"number\":\"19755\"}]";
            List<Score> plist = JsonConvert.DeserializeObject<List<Score>>(json);
            foreach (Score score in plist)
            {
                Console.WriteLine("user: {0}, number: {1}", score.user, score.number);    
            }
        }
    }
