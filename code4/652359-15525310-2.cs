    public class SpecificClass
    {
    }
    public class Specializer
    {
        public bool GenericCalled;
        public bool SpecializedCalled;
        public bool Save<T>(T entity) where T : class
        {
            GenericCalled = true;
            return true;
        }
        public bool Save(SpecificClass entity)
        {
            SpecializedCalled = true;
            return true;
        }
    }
    public class Tests
    {
        [Test]
        public void TestSpecialization()
        {
            var x = new Specializer();
            x.Save(new SpecificClass());
            Assert.IsTrue(x.SpecializedCalled);
            Assert.IsFalse(x.GenericCalled);
        }
    }
