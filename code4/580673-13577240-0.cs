        [TestMethod]
        public void CsvParser()
        {
            string columns = "Device,Id";
            string source = "Dev1,id1" + Environment.NewLine + "Dev1,id2" + Environment.NewLine + "Dev2,id3" + Environment.NewLine + "Dev2,id4";
            List<string> columnNames = columns.Split(',').ToList();
            int keyIndex = columnNames.IndexOf("Device");
            int valueIndex = columnNames.IndexOf("Id");
            GroupByKey(keyIndex, valueIndex, source);
        }
        private void GroupByKey(int keyIndex, int valueIndex, string source)
        {
            LineReader reader = new LineReader(new StringReader(source));
            Func<string[], string> keySelector = lineItems => lineItems[keyIndex];
            Func<string[], string> valueSelector = lineItems => lineItems[valueIndex];
            List<string> idsByDev = reader
                // .Skip(1)  <-- Uncomment if first row contains headers
                .GroupBy(keySelector, valueSelector, StringComparer.OrdinalIgnoreCase)
                .Select(device => device.Key + "," + string.Join(",", device))
                .ToList()
                ;
            Console.WriteLine( string.Join(Environment.NewLine, idsByDev ));
        }
        public class LineReader : IEnumerable<string[]>
        {
            private readonly TextReader source;
            public LineReader( TextReader source )
            {
                this.source = source;
            }
            public IEnumerator<string[]> GetEnumerator()
            {
                return new LineReaderEnumerator(this.source);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            private class LineReaderEnumerator : IEnumerator<string[]>
            {
                private TextReader source;
                public LineReaderEnumerator(TextReader source)
                {
                    this.source = source;
                }
                public void Dispose()
                {
                    this.source.Dispose();
                }
                public bool MoveNext()
                {
                    // Replace these lines with a good CSV parser
                    string line = source.ReadLine();
                    if (!String.IsNullOrEmpty(line))
                    {
                        this.Current = line.Split(',');
                    }
                    else
                    {
                        this.Current = null;
                    }
                    return this.Current != null;
                }
                public void Reset()
                {
                    throw new NotImplementedException();
                }
                public string[] Current { get; private set; }
                object IEnumerator.Current
                {
                    get { return Current; }
                }
            }
        }
