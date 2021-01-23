    public class MyCalculator : ICalculator
    {
        private IOne _oneFirst;
        private IOne _oneSecond;
        private ITwo _twoFirst;
        private ITwo _twoSecond;
        private IThree _three;
        public MyCalculator([Named("Val")] IOne oneFirst, [Named("ED")] IOne oneSecond,
                            [Named("Val")] ITwo twoFirst, [Named("ED")] ITwo twoSecond, IThree three)
        {
            _oneFirst = oneFirst;
            _oneSecond = oneSecond;
            _twoFirst = twoFirst;
            _twoSecond = twoSecond;
            _three = three;
        }
        public void Calculate()
        {
        }
    }
