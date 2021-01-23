    // usage:
    [TestMethod]
    public void example()
    {
        UserSessionData.CustomerNumber.Set("cust num");
        Assert.AreEqual("cust num", UserSessionData.CustomerNumber.Get());
    }
    // implementation:
    public enum UserSessionData
    {
        CustomerNumber,
        FirstName,
    }
    public static class UserSessionDataHelper
    {
        private static Dictionary<string, string> values = new Dictionary<string, string>();
        private static string GetName(this UserSessionData field)
        {
            return Enum.GetName(typeof(UserSessionData), field);
        }
        public static string Get(this UserSessionData field)
        {
            return values[field.GetName()];
        }
        public static void Set(this UserSessionData field, string value)
        {
            values[field.GetName()] = value;
        }
    }
