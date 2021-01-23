    protected double[] theta = null;
    protected double[] delta_theta = null;
    public double this[int index] {
            get { return theta[index]; }
            set { theta[index] = value; }
    }
 
    public Indexer DeltaTheta { 
          // can be optimized according to delta_theta lifecycle
          get {return new Indexer(delta_theta);} 
    }
    
    // internal indexere wrapper
    public class Indexer{
          double [] _data;
          public DoubleIndexer(double[] data ){   
              _data = data;
          }
          
          public double this[int index] {
                get { return _data[index]; }
                set { _data[index] = value; }
          }
    }
