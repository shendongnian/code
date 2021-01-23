    public enum RoleEnum
    {
        Administrator = 4,
        Official = 1,
        Trader = 3,
        HeadOfOffice = 2
    }
    public static class RoleEnumExtension
    {
        private static readonly ResourceManager Resource =
            new ResourceManager("Project.CommonResource", typeof(CommonResource).Assembly);
        public static string Display(this RoleEnum role)
        {
            return Resource.GetString("RoleType_" + role);
        }
    }
