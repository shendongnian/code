    [TestClass]
    public class MyQueryUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            BitQuery bitQuery = new BitQuery();
            var result = bitQuery.Query("ADDR");
            Assert.IsTrue(result.Count==3);
        }
        [TestMethod]
        public void TestMethod2()
        {
            BitQuery bitQuery = new BitQuery();
            var result = bitQuery.Query("XXX");
            Assert.IsTrue(result.Count == 2);
        }
        [TestMethod]
        public void TestMethod3()
        {
            BitQuery bitQuery = new BitQuery();
            var result = bitQuery.Query("CMS");
            Assert.IsTrue(result.Count==1);
        }
        [TestMethod]
        public void TestMethod4()
        {
            BitQuery bitQuery = new BitQuery();
            var result = bitQuery.Query("CMSR");
            Assert.IsTrue(result.Count == 1);
        }
        [TestMethod]
        public void TestMethod5()
        {
            BitQuery bitQuery = new BitQuery();
            var result = bitQuery.Query("CM");
            Assert.IsTrue(result.Count == 2);
        }
        [TestMethod]
        public void TestMethod6()
        {
            BitQuery bitQuery = new BitQuery();
            var result = bitQuery.Query("DUMMY");
            Assert.IsTrue(result.Count == 2);
        }
        [TestMethod]
        public void TestMethod7()
        {
            BitQuery bitQuery = new BitQuery();
            var result = bitQuery.Query("");
            Assert.IsTrue(result.Count == 5);
        }
    }
    public class BitQuery
    {
        public ObservableCollection<bit> bitfields = new ObservableCollection<bit>();
        public BitQuery()
        {
            bitfields.Add(new bit { name_ = "CMSRC_XXX_ADDR" });
            bitfields.Add(new bit { name_ = "CMDST_XXX_ADDR" });
            bitfields.Add(new bit { name_ = "TXDAT_DMA_ST_ADDR" });
            bitfields.Add(new bit { name_ = "WWWW_DUMMY" });
            bitfields.Add(new bit { name_ = "ABCDE_DUMMY" });
        }
        public List<bit> Query (string text)
        {
            string txtOrig = text;
            string lower = txtOrig.ToLower();
            string normalize = txtOrig.Normalize();
            var bitfieldsfiltered = from bit in bitfields
                                    let name = bit.name_
                                    where IsMatch(txtOrig, name)
                                    select bit;
            return bitfieldsfiltered.ToList();
        }
        private bool IsMatch(string txtOrig, string name)
        {
            if (name.StartsWith(txtOrig, StringComparison.InvariantCultureIgnoreCase)) return true;
            if (name.IndexOf(txtOrig, 0, StringComparison.OrdinalIgnoreCase) >= 0) return true;
            return false;
        }
    }
    public class bit
    {
        public string name_ { get; set; }
        public override string ToString()
        {
            return name_;
        }
    }
