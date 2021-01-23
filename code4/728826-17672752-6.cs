    class NullHelper
    {
        public static bool ChainNotNull<TFirst, TSecond, TThird, TFourth>(TFirst item1, Func<TFirst, TSecond> getItem2, Func<TSecond, TThird> getItem3, Func<TThird, TFourth> getItem4)
        {
            if (item1 == null)
                return false;
            var item2 = getItem2(item1);
            if (item2 == null)
                return false;
            var item3 = getItem3(item2);
            if (item3 == null)
                return false;
            var item4 = getItem4(item3);
            if (item4 == null)
                return false;
            return true;
        }
    }
