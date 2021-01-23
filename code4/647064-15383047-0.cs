    public class TestSectionClass: MyConfigurationSection
    {
        public TestSectionClass(string testUserName)
        {
            this["userName"] = testUserName;
        }
    }
