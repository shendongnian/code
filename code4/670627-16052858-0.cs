        public class BookCharacteristicEqualityComparer : IEqualityComparer<BookCharacteristic>
        {
            public bool Equals(BookCharacteristic x, BookCharacteristic y)
            {
 	            return x.CharacteristicID == y.CharacteristicID && x.Value == y.Value;
            }
            public int GetHashCode(BookCharacteristic obj)
            {
 	            return obj.CharacteristicID * obj.Value;
            }
        }
