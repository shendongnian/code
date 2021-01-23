    public class Example
        {
            
            public interface ITransform<D> // or <in D> --> seems to make no difference here
            {
                void Transform(D data); //contravariant in ITranform<out D>.
                //D Transform(string input);  //covariance ok
            }
    
            public interface ISelection { }
    
            public interface IValue : ISelection { }
    
            public interface IEditor : ITransform<IValue> { }
            public interface ISelector : IEditor, ITransform<ISelection> { }
    
            class Value : IValue { }
            class Editor : IEditor
            {
                public void Transform(IValue data)
                {
                    throw new NotImplementedException();
                }
            } 
            class Foo : Editor, ISelector
            {
                public void Transform(ISelection data)
                {
                    throw new NotImplementedException();
                }
            }  
    
            public void Whatever()
            {
                Value v = new Value();
                Foo s1 = new Foo();
                IEditor s2 = s1;
    
                s1.Transform(v); // resolves to Foo.Tranform(ISelection)
                s2.Transform(v); // resolves to ITransform<IValue>     --> cast into IEditor, which sig says ITransform<IValue>
    
            }
    
          }
