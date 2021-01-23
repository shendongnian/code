    [Fact]
        public void AcceptsAMemoryStream()
        {
            MemoryFile file;
            using (var f = File.OpenRead("SampleData.xlsx"))
            {
                file = new MemoryFile(f, "multipart/form-data", "SampleData.xlsx");
                using (var importer = new DataImportHelper(file, "Temp/"))
                {
                    var products = importer.All<Product>();
                    Assert.NotEmpty(products);
                }
            }
        }
