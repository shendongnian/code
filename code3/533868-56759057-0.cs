 c-sharp
using Spire.Doc;
    public sealed class TestNcWorker
    {
        [TestMethod]
        public void DocTemplate3851PageCount()
        {
            var docTemplate3851 = Resource.DocTemplate3851;
            using (var ms = new MemoryStream())
            {
                ms.Write(docTemplate3851, 0, docTemplate3851.Length);
                Document document = new Document();
                document.LoadFromStream(ms, FileFormat.Docx);
                Assert.AreEqual(2,document.PageCount);
            }
            var barCoder = new BarcodeAttacher("8429053", "1319123", "HR3514");
            var barcoded = barCoder.AttachBarcode(docTemplate3851).Value;
            using (var ms = new MemoryStream())
            {
                ms.Write(barcoded, 0, barcoded.Length);
                Document document = new Document();
                document.LoadFromStream(ms, FileFormat.Docx);
                Assert.AreEqual( 3, document.PageCount);
                
            }
        }
    }
