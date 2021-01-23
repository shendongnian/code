     [TestFixture]
        public class ToTestFixture
        {
            [SetUp]
            public void SetUp()
            {
                _instance = new ToTest();
                _instance.InputDataStore(1, "1");
                _instance.InputDataStore(2, "2");
                _instance.InputDataStore(3, "3");
                _instance.InputDataStore(4, "4");
            }
    
            private ToTest _instance;
            [TestCase("{DS1}","1")]
            [TestCase("{DS2}", "2")]
            [TestCase("{DS3}", "3")]
            [TestCase("{DS4}", "4")]
            [TestCase("{DS1}{DS2}{DS3}{DS4}", "1234")]
            [Test]
            public void TestPrefixReplacements(string input, string expectedResult)
            {
    
                _instance.Prefix = input;
  
                //Call the input method which will raise the Output event which we can test
                _instance.Input("Any string goes here as we test only prefix." );
    
                Assert.AreEqual(expectedResult, _instance.Prefix);
            }
    
        }
    
        internal enum OutputsEnum
        {
            OutputBeforeModified,
            OutputModified,
            OutputAfterModified
        }
    
        public class ToTest
        {
            public event Action<int, string> Output = (x, result) => Console.WriteLine(x.ToString() + result);
    
            public string Prefix { get; set; }
    
            public string Postfix { get; set; }
    
            private List<string> DataStoreContents = new List<string>() {"1", "2", "3", "4"};
    
            public void Input(string Data)
            {
                if (Output != null)
                {
                    if (!String.IsNullOrEmpty(Prefix))
                    {
                        Prefix = Prefix.Replace("{DS1}", DataStoreContents[0]);
                        Prefix = Prefix.Replace("{DS2}", DataStoreContents[1]);
                        Prefix = Prefix.Replace("{DS3}", DataStoreContents[2]);
                        Prefix = Prefix.Replace("{DS4}", DataStoreContents[3]);
                    }
    
                    if (!String.IsNullOrEmpty(Postfix))
                    {
                        Postfix = Postfix.Replace("{DS1}", DataStoreContents[0]);
                        Postfix = Postfix.Replace("{DS2}", DataStoreContents[1]);
                        Postfix = Postfix.Replace("{DS3}", DataStoreContents[2]);
                        Postfix = Postfix.Replace("{DS4}", DataStoreContents[3]);
                    }
    
                    Output((int) OutputsEnum.OutputBeforeModified, Data);
                    Output((int) OutputsEnum.OutputModified, Prefix + Data + Postfix);
                    Output((int) OutputsEnum.OutputAfterModified, Data);
                }
            }
            public void InputDataStore(int DataStore, string Data)
            {
                if (DataStore < 1 || DataStore > 4)
                    throw new ArgumentOutOfRangeException("Datastore number out of range");
    
                DataStoreContents[DataStore - 1] = Data;
            }
        }
