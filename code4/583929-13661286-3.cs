    public class SampleClass<T>
        where T : C, ICopyable<T> // added constraint
    {
        public void Stuff()
        {
            T favoriteThing = ...
            ...
            ICopyable<T> copyable = favoriteThing;
            T copy = copyable.Copy(params); // no cast needed
            ...
        }
    }
