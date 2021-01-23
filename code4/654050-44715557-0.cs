    public MemoryStream CreateCsvFileAsMemoryStream(List<TestItem> testItems) {
            var engine = new FileHelperEngine<TestItemCsvMapping>();
            var items = testItems.Select(ti => (TestItemCsvMapping)ti).ToList();
            engine.HeaderText = engine.GetFileHeader();
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            engine.WriteStream(sw, items);
            sw.Flush();
            //var reader = new StreamReader(ms);
            //ms.Position = 0;
            //Console.Write(reader.ReadToEnd());
            ms.Position = 0;
            return ms;
        }
