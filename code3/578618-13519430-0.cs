    public interface IMan<M, W>
    	where M : IMan<M, W>
    	where W : IWoman<W, M>
    {
    	W Sweetheart { get; set; }
    }
    
     public interface IWoman<W, M>
    	where W : IWoman<W, M>
    	where M : IMan<M, W>
    {
    	M Darling { get; set; }
    }
