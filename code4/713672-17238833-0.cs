    public class sampleClass
    {
         private string _mongoFormId;
    
    public string mongoFormId {
                get { return _mongoFormId; }
                set {
                    _mongoFormId = value;
                    revalidateTransformation();
                }
            }
    }
