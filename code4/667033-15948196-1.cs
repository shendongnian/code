    void Main()
    {
            IAaa aa;
            aa = Factory.Get(true);
    }
    
    public class Y
    { }
    
    public class X : Y
    { }
    
    public class W : Y
    { }
    
    public interface IAaa<T> : IAaa
        where T : Y
    {
        void Execute(T ppp);
    }
    
    public interface IAaa
    {
        void Execute(Y ppp);
    }
    
    public abstract class Aaa<T> : IAaa<T>
        where T : Y
    {
        public abstract void Execute(T ppp);
    	void IAaa.Execute(Y ppp)
    	{
    		this.Execute(ppp);
    	}
        protected abstract void Execute(Y ppp);
    }
    
    public class Bbb : Aaa<X>
    {
        public override void Execute(X ppp)
        { }
        protected override void Execute(Y ppp)
        {
    		this.Execute((X)ppp);
    	}
    }
    
    public class Ccc : Aaa<W>
    {
        public override void Execute(W ppp)
        { }
        protected override void Execute(Y ppp)
        {
    		this.Execute((W)ppp);
    	}
    }
    
    public class Factory 
    {
        public static IAaa Get(bool b)
        {
            if(b)
                return new Bbb();
            else
                return new Ccc();
        }
    }
