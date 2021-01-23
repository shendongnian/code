    class Quarter {
        public static int GetQuarter(Datetime date){
            if (date >= beginningOfQuarter1 && date < endOfQuarter1){
                return 1;
            } else { ... }
        }
    }
    // elsewhere
    int someDatesQuarter = Quarter.GetQuarter(someDate);
