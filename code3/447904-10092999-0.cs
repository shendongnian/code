    public sealed class Transaction {
        public string Test { get;set; }
        public string AnotherTest{
            get {
                if (_anotherTest != null)
                {
                    return _anotherTest;
                }
                else
                {
                    int indexLiteryS = Test.IndexOf("S");
                    return Test.Substring(indexLiteryS, 4);
                }
            }
            set {
                _anotherTest = value;
            }
        }
        private string _anotherTest = null;
    }
