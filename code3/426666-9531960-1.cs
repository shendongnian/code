    public class Example
        {
            
            public interface ITransform<D> // or <in D> --> seems to make no difference here
            {
                void Transform(D data); //contravariant in ITranform<out D>.
                //D Transform(string input);  //covariance ok
            }
    
            
