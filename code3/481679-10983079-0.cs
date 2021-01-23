    class Program
    {
        static void Main(string[] args)
        {
            ScoreTextTranslator dec = new ScoreTextTranslator();
            dec.IfAtLeast(0, "stupid");
            dec.IfAtLeast(5, "average intelligence");
            dec.IfAtLeast(6, "smart");
            Console.WriteLine(dec.GetTextForScore(5.7f));
        }
    }
    class ScoreTextTranslator
    {
        Dictionary<float, string> backing = new Dictionary<float, string>();
        public void IfAtLeast(float value, string text)
        {
            backing.Add(value, text);
        }
        public string GetTextForScore(float ActualScore)
        {
            var scoreRange = backing.Keys.Where(a => a <= ActualScore);
            if (scoreRange.Count() == 0)
                throw new Exception("No valid score text exists");
            else
                return backing[scoreRange.Max()];
        }
    }
