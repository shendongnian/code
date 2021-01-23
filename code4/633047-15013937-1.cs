    public static class MapperExtensions 
    {
        public static ThirdType ToThirdType(this ThisType obj)
        {
            return new ThirdType() { P1 = obj.sPropName, P2 = obj.dPropName };
        }
        public static ThirdType ToThirdType(this ThatType obj)
        {
            return new ThirdType() { P1 = obj.sPropName2, P2 = obj.dPropName2 };
        }
    }
