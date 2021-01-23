    public class C <T> where T : A <T>
    {
        someMethod(...)
        {
            ...
            byte[] bytes; // some bytes
            T = new T().Deserialize(bytes); // should be T.Deserialize(bytes)
            ...
        }
    }
