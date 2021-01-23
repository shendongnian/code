    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    namespace NunitDemo
    {
        public class AddTwoNumbers
        {
            private int _first;
            private int _second;
    
            public int AddTheNumbers(int first, int second)
            {
                _first = first;
                _second = second;
    
                return first + second;
            }
        }
    
        [TestFixture]
        public class AddTwoNumbersTest 
        {
    
            [Test, TestCaseSource("GetMyTestData")]
            public void AddTheNumbers_TestShell(int first, int second, int expectedOutput)
            {
                AddTwoNumbers addTwo = new AddTwoNumbers();
                int actualValue = addTwo.AddTheNumbers(first, second);
    
                Assert.AreEqual(expectedOutput, actualValue, 
                    string.Format("AddTheNumbers_TestShell failed first: {0}, second {1}", first,second));
            }
    
            private IEnumerable<int[]> GetMyTestData()
            {
                using (var csv = new StreamReader("test-data.csv"))
                {
                    string line;
                    while ((line = csv.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        int first = int.Parse(values[0]);
                        int second = int.Parse(values[1]);
                        int expectedOutput = int.Parse(values[2]);
                        yield return new[] { first, second, expectedOutput };
                    }
                }
            }
        }
    }
