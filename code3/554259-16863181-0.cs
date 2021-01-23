    public class BlobTest
    {
        public int Id { get; set; }
        public byte[] Blob { get; set; }
    }
    [TestMethod]
    public void TestSaveBlob()
    {
        var conn = new SQLiteConnection("path_to_db");
        conn.CreateTable<BlobTest>();
        var expected = new BlobTest() { Id = 1 };
        expected.Blob = new byte[10];
        for (int idx = 0; idx < expected.Blob.Length; idx++)
        {
            expected.Blob[idx] = (byte)(idx + 1);
        }
        conn.Insert(expected);
        var actual = conn.Table<BlobTest>().FirstOrDefault();
        Assert.IsTrue(actual.Id != 0, string.Format("actual.Id == '{0}', expected non-zero", actual.Id));
        Assert.IsTrue(actual.Id == expected.Id, string.Format("actual.Id == '{0}', expected '{1}'", actual.Id, expected.Id));
        Assert.IsTrue(actual.Blob != null, string.Format("actual.Blob == '{0}', expected non-null", actual.Blob));
        for (int idx = 0; idx < expected.Blob.Length; idx++)
        {
            Assert.IsTrue(expected.Blob[idx] == actual.Blob[idx], string.Format("actual.Blob[{0}] == '{1}', expected '{2}'", idx, actual.Blob[idx], expected.Blob[idx]));
        }
    }
