        public class MultiKeyGesture
        {
            private List<Keys> _keys;
            private Keys _modifiers;
            public MultiKeyGesture(IEnumerable<Keys> keys, Keys modifiers)
            {
                _keys = new List<Keys>(keys);
                _modifiers = modifiers;
                if (_keys.Count == 0)
                {
                    throw new ArgumentException("At least one key must be specified.", "keys");
                }
            }
            private int currentindex;
            public bool Matches(KeyEventArgs e)
            {
                if (e.Modifiers == _modifiers && _keys[currentindex] == e.KeyCode)
                    //at least a partial match
                    currentindex++;
                else
                    //No Match
                    currentindex = 0;
                if (currentindex + 1 > _keys.Count)
                {
                    //Matched last key
                    currentindex = 0;
                    return true;
                }
                return false;
            }
        }
