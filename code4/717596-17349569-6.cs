    public class Character
    {
        private string char_name;
        private string char_descr;
        private byte char_level;
        private byte char_attack;
        private byte char_defence;
        private bool char_defeat;
        public Character(string name, string desc, byte level, byte attack, byte defence,
                         bool defeat)
        {
            char_name = name;
            char_descr = "";
            char_level = level;
            char_attack = attack;
            char_defence = defence;
            char_defeat = defeat;
        }
        public string GetCharacterName()
        {
            return char_name;
        }
        public string GetCharacterDescription()
        {
            return char_descr;
        }
        public void SetCharacterDescription(string descr)
        {
            char_descr = descr;
        }
        public byte GetCharLevel()
        {
            return char_level;
        }
        public byte GetCharacterAttack()
        {
            return char_attack;
        }
    }
