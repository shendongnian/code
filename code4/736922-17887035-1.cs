    public class RPicture
    {
        public Image Image;
        public string FilePath;
    }
    
    public class RPictures : Dictionary<RPicture>
    {
    	public bool Remove(TKey key)
    	{
            this[key].Image.Dispose();
    		this.Remove(key);
    	}
    }
