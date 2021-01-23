    static class ExtendInt
    {
        static public int Mod(this int stat)
        {
            return stat / 2;
        }
    }
    class UseExtendedInt
    {
        void UseIt()
        {
            int a = 1;
            int b = a.Mod();
        }
    }
