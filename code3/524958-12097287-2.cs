    internal static class MyBaseHelper {
        public static void CopyFromBase(this MyBase target, MyBase source) {
            target.DateAdded = source.DateAdded;
        }
    }
