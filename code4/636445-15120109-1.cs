    public class Document
    {
    	private DownloadBinaryDelegate _downloadBinaryDelegate;
    	public void SetDownloadBinaryDelegate(DownloadBinaryDelegate downloadBinary)
    	{
    		if (downloadBinary == null)
    			throw new ArgumentNullException("downloadBinary");
    
    		_downloadBinaryDelegate = downloadBinary;
    	}
    
    	private TextReaderDelegate _textReaderDelegate;
    	public void SetTextReaderDelegate(TextReaderDelegate readerDelegate)
    	{
    		if (readerDelegate == null)
    			throw new ArgumentNullException("readerDelegate");
    
    		_textReaderDelegate = readerDelegate;
    	}
    
    	private bool _binaryIsSet;
    	private byte[] _bytes;
    
    	public void SetBinary(byte[] bytes, bool forceOverwrite = false)
    	{
    		if (_binaryIsSet && !forceOverwrite)
    			return;
    		
    		_bytes = bytes;
    		_binaryIsSet = true;
    	}
    
    	public byte[] GetBinary()
    	{
    		if (_binaryIsSet)
    			return _bytes;
    
    		if (_downloadBinaryDelegate == null)
    			throw new InvalidOperationException("No delegate attached to DownloadBinaryDelegate. Use SetDownloadBinaryDelegate.");
    
    		SetBinary(_downloadBinaryDelegate(this));
    		_downloadBinaryDelegate = null; // unhock delegate as it's no longer needed.
    
    		return _bytes;
    	}
    
    	public bool TryGetBinary(out byte[] bytes)
    	{
    		if (_binaryIsSet)
    		{
    			bytes = _bytes;
    			return true;
    		}
    
    		if (_downloadBinaryDelegate != null)
    		{
    			bytes = GetBinary(); // is this legit?
    			return true;
    		}
    
    		bytes = null;
    		return false;
    	}
    
    	private bool _textIsSet;
    	private string _text;
    
    	public void SetText(string text, bool forceOverwrite = false)
    	{
    		if (_textIsSet && !forceOverwrite)
    			return;
    
    		_text = text;
    		_textIsSet = true;
    	}
    
    	public string GetText()
    	{
    		if (_textIsSet)
    			return _text;
    
    		if (_textReaderDelegate == null)
    			throw new InvalidOperationException("No delegate attached to TextReaderDelegate. Use SetTextReaderDelegate.");
    
    		SetText(_textReaderDelegate(this)); // this delegate will call Binary and return the read text.
    		_textReaderDelegate = null; // unhock delegate as it's no longer needed.
    
    		return _text;
    	}
    
    	public bool TryGetText(out string text)
    	{
    		byte[] bytes;
    		if (!TryGetBinary(out bytes))
    		{
    			text = null;
    			return false;
    		}
    		
    		if (_textIsSet)
    		{
    			text = _text;
    			return true;
    		}
    
    		if (_textReaderDelegate != null)
    		{
    			text = GetText(); // is this legit?
    			return true;
    		}
    
    		text = null;
    		return false;
    	}
    }
