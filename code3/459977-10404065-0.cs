    class RedMarble : Marble {
        public static IEnumerable<string> Nicknames {
            get {
                return new List<string>(Marble.BaseNicknames) {
                    "Ruby"
                };
            }
        }
    }
