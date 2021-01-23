    public class CharacterSanitizer
    {
        private static Dictionary<string, string> characterMappings = new Dictionary<string, string>();
        static CharacterSanitizer()
        {
            characterMappings.Add("é", "e");
            characterMappings.Add("ê", "e");
            //...
        }
    
        public static string mapCharacter(string input)
        {
            string output;
            if (characterMappings.TryGetValue(input, out output))
            {
                return output;
            }
            else
            {
                return input;
            }
        }
    }
