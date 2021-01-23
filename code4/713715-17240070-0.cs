    public static A AddData(byte[] Data)
    {
        //analyze data
        if (BoolFromAnalyzedData == true)
        {
            AFirstType a = new AFirstType();
            a.SomeInt = IntFromAnalyzedData;
            return a;
        }
        else
        {
            ASecondType a = new ASecondType();
            a.SomeString = StringFromAnalyzedData;
            return a;
        }
    }
