    var testxml =
                @"<base>
                    <elem1 number='1'>
                        <elem2>yyy</elem2>
                        <elem3>xxx   <yyy zzz aaa</elem3>
                    </elem1>
                </base>";
    
                string result;
    
                using (var source = new MemoryStream(Encoding.ASCII.GetBytes(testxml)))
                using(var target = new MemoryStream()) {
    
                    XmlCleaner cleaner = new XmlCleaner();
                    cleaner.Clean(source, target);
    
                    target.Position = 0;
                    using (var reader = new StreamReader(target))
                    {
                        result = reader.ReadToEnd();
                    }
                }
    
                XDocument.Parse(result);
    
                var expectedResult = 
                    @"<base>
                    <elem1 number='1'>
                        <elem2>yyy</elem2>
                        <elem3>xxx   &lt;yyy zzz aaa</elem3>
                    </elem1>
                </base>";
                Debug.Assert(result == expectedResult);
