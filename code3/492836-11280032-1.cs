    public class MyClass
    {
        private readonly int m_Dependency1;
        private readonly string m_Dependency2;
        public MyClass(int dependency1, string dependency2)
        {
            m_Dependency1 = dependency1;
            m_Dependency2 = dependency2;
        }
        public char MethodUnderTest()
        {
            if (m_Dependency1 > 42)
            {
                return m_Dependency2[0];
            }
            return ' ';
        }
    }
    public class MyClassTests
    {
        [Fact]
        public void MethodUnderTest_dependency1is43AndDependency2isTest_ReturnsT()
        {
            var underTest = new MyClass(43, "Test");
            var result = underTest.MethodUnderTest();
            Assert.Equal('T', result);
        }
    }
    ...
    var myClass = new MyClass(ConfigurationLoader.Dependency1, ConfigurationLoader.Dependency2);
