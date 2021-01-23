    public class Character
    {
        //YOUR FIELDS HERE
        public Character(string name, string desc, byte level, byte attack, byte defence,
                         bool defeat)
        {
        this.char_name = name;
        this.char_descr = "";
        this.char_level = level;
        this.char_attack = attack;
        this.char_defence = defence;
        this.char_defeat = defeat;
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
            this.char_descr = descr;
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
