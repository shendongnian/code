    // This class is used to represent the extracted details
    public class DeathDetails
    {
        public DeathDetails()
        {
            this.KilledBy = new List<string>();
        }
        public string DeathDate { get; set; }
        public List<String> KilledBy { get; set; }
        public int PlayerLevel { get; set; }
    }
    public class CharacterPageParser
    {
        public string CharacterName { get; private set; }
        
        public CharacterPageParser(string characterName)
        {
            this.CharacterName = characterName;
        }
        public List<DeathDetails> GetDetails()
        {
            string url = "http://www.tibia.com/community/?subtopic=characters&name=" + this.CharacterName;
            string content = GetContent(url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(content);
            HtmlNodeCollection tables = document.DocumentNode.SelectNodes("//div[@id='characters']//table");
            HtmlNode table = GetCharacterDeathsTable(tables);
            List<DeathDetails> deaths = new List<DeathDetails>();
            for (int i = 1; i < table.ChildNodes.Count; i++)
            {
                DeathDetails details = BuildDeathDetails(table, i);
                deaths.Add(details);
            }
            return deaths;
        }
        private static string GetContent(string url)
        {
            using (System.Net.WebClient c = new System.Net.WebClient())
            {
                string content = c.DownloadString(url);
                return content;
            }
        }
        private static DeathDetails BuildDeathDetails(HtmlNode table, int i)
        {
            DeathDetails details = new DeathDetails();
            HtmlNode tableRow = table.ChildNodes[i];
            //every row should have two cells in it
            if (tableRow.ChildNodes.Count != 2)
            {
                throw new Exception("Html format may have changed");
            }
            HtmlNode deathDateCell = tableRow.ChildNodes[0];
            details.DeathDate = System.Net.WebUtility.HtmlDecode(deathDateCell.InnerText);
            HtmlNode deathDetailsCell = tableRow.ChildNodes[1];
            // get inner text to parse for player level and or creature name
            string deathDetails = System.Net.WebUtility.HtmlDecode(deathDetailsCell.InnerText);
            // get player level using regex
            Match playerLevelMatch = Regex.Match(deathDetails, @" level ([\d]+) ", RegexOptions.IgnoreCase);
            int playerLevel = 0;
            if (int.TryParse(playerLevelMatch.Groups[1].Value, out playerLevel))
            {
                details.PlayerLevel = playerLevel;
            }
            if (deathDetailsCell.ChildNodes.Count > 1)
            {
                // death details contains links which we can parse for character names
                foreach (HtmlNode link in deathDetailsCell.ChildNodes)
                {
                    if (link.OriginalName == "a")
                    {
                        string characterName = System.Net.WebUtility.HtmlDecode(link.InnerText);
                        details.KilledBy.Add(characterName);
                    }
                }
            }
            else
            {
                // player was killed by a creature - capture creature name
                Match creatureMatch = Regex.Match(deathDetails, " by (.*)", RegexOptions.IgnoreCase);
                string creatureName = creatureMatch.Groups[1].Value;
                details.KilledBy.Add(creatureName);
            }
            return details;
        }
        private static HtmlNode GetCharacterDeathsTable(HtmlNodeCollection tables)
        {
            foreach (HtmlNode table in tables)
            {
                // Get first row
                HtmlNode tableRow = table.ChildNodes[0];
                // check to see if contains enough elements
                if (tableRow.ChildNodes.Count == 1)
                {
                    HtmlNode tableCell = tableRow.ChildNodes[0];
                    string title = tableCell.InnerText;
                    // skip this table if it doesn't have the right title
                    if (title == "Character Deaths")
                    {
                        return table;
                    }
                }
            }
            return null;
        }
