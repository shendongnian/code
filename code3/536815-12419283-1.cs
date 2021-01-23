    public static class Extensions
    {
        public static string getText(this PageTypes type)
        {
            switch (type)
            {
                case PageTypes.A:
                    return "0001000";
                case PageTypes.F:
                    return "0002000";
                default:
                    return null;
            }
        }
    }
