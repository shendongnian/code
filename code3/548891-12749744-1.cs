     [TestClass()]
    public class FormManagerTest
    {
        
        [TestMethod()]
        public void FormManagerTestSource()
        {
            var dgv = new System.Windows.Forms.DataGridView();
            var _source = new List<Pair>()
        {
            new Pair() { Key="1", Value = "one" },
            new Pair() { Key = "2", Value = "two" }
        };
            Assert.AreEqual(2, _source.Count); 
            //If you want to test dgv row count
            dgv.DataSource = _source;
            Assert.AreEqual(2, dataGridView1.Rows.Count);
        }
    }
