    [TestFixture]
    public class UserDetailsTests
    {
        [Test]
        public void TestData()
        {
            FileHelperEngine engine = new FileHelperEngine(typeof(UserDetails));
            UserDetails[] res = engine.ReadFile("TestData.csv") as UserDetails[];
            Assert.AreEqual(res[0].UserName, "User 1");
            Assert.AreEqual(res[0].Password, "Password 1");
            Assert.AreEqual(res[1].UserName, "User 2");
            Assert.AreEqual(res[2].UserName, "User 3");
        }
    }
