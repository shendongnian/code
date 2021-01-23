    public class DayOfWeekComparer : IComparer<DayOfWeek> {
        public int Compare(DayOfWeek x, DayOfWeek y) {
            return ModifyDayOfWeek(x).CompareTo(ModifyDayOfWeek(y));
        }
 
        private static int ModifyDayOfWeek(DayOfWeek x) {
            // redefine Sunday so it appears at the end of the ordering
            return x == DayOfWeek.Sunday ? 7 : (int)x;
        }
    }
