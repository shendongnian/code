    public struct PersonName
    {
        public PersonName(string first, string last)
        {
            First = first;
            Last = last;
        }
        public string First;
        public string Last;
    }
    // Error at compile time: Type 'PersonName' in interface list is not an interface
    public struct AngryPersonName : PersonName
    {
        public string AngryNickname;
    }
