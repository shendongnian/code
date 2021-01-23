    static extern int TestPass (
    [MarshalAs(UnmanagedType.LPArray, SizeConst=5,
    ArraySubType=UnmanagedType.R4)]
    float [] yields);
    
    private void BtnTestClick(object sender, System.EventArgs e)
    {
    float [] floatArray = new float[5] {9.9F, 9.9F, 9.9F, 9.9F, 9.9F};
    TestPass(floatArray);
    
    // floatArray.Length == 0 after the function call
    
    for ( int i = 0; i < floatArray.Length; i++ )
    Trace.WriteLine(floatArray[i]);
    }
