    namespace TestesGerais
    {
        public class MyClass
        {
            public static void selectTop20Tags(Dictionary<string, int> list)
            {
                //Outputs the top 20 most common hashtags in descending order
                foreach (KeyValuePair<string, int> pair in list.OrderByDescending(key => key.Value).Take(20))
                {
                    Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
                }
            }
        }
    
        [TestClass]
        public class UnitTest6
        {
            [TestMethod]
            [HostType("Moles")]
            public void TestMethod1()
            {
                // Arrange
                var actual = new List<string>();
                MConsole.WriteLineStringObjectObject = (s, o1, o2) => actual.Add(string.Format(s, o1, o2));
                var dic = new Dictionary<string, int>();
                for (int i = 1; i < 30; i++)
                    dic.Add(string.Format("String{0}", i), i);
                var expected = new List<string>();
                expected.AddRange(new[] { "String29, 29", "String28, 28", "String27, 27", "String26, 26", "String25, 25", "String24, 24", "String23, 23", "String22, 22", "String21, 21", "String20, 20", "String19, 19", "String18, 18", "String17, 17", "String16, 16", "String15, 15", "String14, 14", "String13, 13", "String12, 12", "String11, 11", "String10, 10" });
                // Act
                MyClass.selectTop20Tags(dic);
                // Assert
                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
