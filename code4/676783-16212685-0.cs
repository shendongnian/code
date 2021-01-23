    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            var ret = "this.is.my.test.string".MySplit(".", new int[] {0,1,4 });//this.is.string
    
        }
    }
    public static class Process {
        public static string MySplit(this string Source, string seprator, int[] positionTokeep) {
            var items = Source.Split(seprator.ToCharArray());
            string ret = string.Empty;
            for (int i = 0; i < positionTokeep.Length; i++) {
                ret += items[positionTokeep[i]] + seprator;
            }
            if (!string.IsNullOrWhiteSpace(ret)) {
                ret = ret.Substring(0,ret.Length - seprator.Length);
            }
            return ret;
        }
    }
