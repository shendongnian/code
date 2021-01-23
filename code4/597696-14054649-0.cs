    public abstract class BaseProcessor<T> 
    {
       protected abstract T makeProcessor();
       public T Process(String m_doc)
       {
           T data = makeProcessor(); // this is not working
