            [TestMethod]
        public void Linq()
        {
            var items = new List<DocSpcItem>();
            //2146943 
            for (var i = 2146930; i <= 2146950; i++)
            {
                items.Add(new DocSpcItem() { DocID = i, FinishingOptionsDesc = new string[] { i.ToString() } });
            }
            var item = items.FirstOrDefault(i => i.DocID == 2146943);
            if (item != null)
            {
                item.FinishingOptionsDesc = new string[]{"The New Value"};
            }
        }
    }
    public class DocSpcItem
    {
        public string[] FinishingOptionsDesc { get; set; }
        public int DocID { get; set; }
    }
