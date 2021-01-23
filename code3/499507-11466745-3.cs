    public class Factory
    {
        public static IFamily CreateObj(string condition)
        {
            switch(condition)
            {
                case("F"):
                    return new Father();
                case("S"):
                    return new Son();
                default:
                    throw new exception("you have no choice");
            }
        }
    }
