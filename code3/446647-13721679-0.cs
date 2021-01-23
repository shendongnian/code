    public class zScannerDelegate : ZBarReaderDelegate
    {
	public delegate void ScanResult(string scanstrring);
	public event ScanResult ScannedCode;
	public zScannerDelegate ()
	{
	}
	public override void FinishedPickingMedia (UIImagePickerController picker, NSDictionary info)
	{
		ZBarSymbolSet result = null;
		
		string retstr = string.Empty;
		foreach (var sresult in info.Values) {
			if (sresult is ZBarSymbolSet) {
				result = sresult as ZBarSymbolSet;
				break;
			}
		}
		if (result != null) {
			foreach (var itema in result) {
				Console.WriteLine (itema.Data);
				retstr = itema.Data;
				ScanResult ret = ScannedCode;
				if (ret != null)
					ret(retstr);
			}
		}
	}
   }
