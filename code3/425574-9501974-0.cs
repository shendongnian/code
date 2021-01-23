    public sealed class Roles
    {
        public const string BRANCH = "Branch";
        public const string CUSTOMER = "Customer";
        public static bool IsCustomer(string role)
        {
            return role == CUSTOMER;
        }
    }
