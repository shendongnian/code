    class Human
        {     
        private string _name = string.Empty;    
        public String Name
            {
                get
                {
                    char[] letters = _name.ToCharArray();  // use the backing variable instead of Name
                    // upper case the first char
                    letters[0] = char.ToUpper(letters[0]);
                    // return the array made of the new char array
                    return new String(letters);
                    //return Name.First().ToString().ToUpper() + String.Join("", Name.Skip(1));
                    return new String(;// ToUpperFirstLetter(this.Imie);
                }
                set
                {
                    _name = value;
                }
            }
