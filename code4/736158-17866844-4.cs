    public static class ManaHelper {
        public static bool IsGreaterThan(this string mana, int value, bool includeX) {
    
            if (mana == "X") return includeX;
            int manaValue;
            return int.TryParse(mana, out manaValue) && manaValue > value;
        }
    }
