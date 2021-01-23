    public class CodeScannedEventArgs : EventArgs
    {
    	public CodeScannedEventArgs(string scannedCode)
    	{
    		ScannedCode = scannedCode;
    	}
    
    	public string ScannedCode { get; set; }
    }
