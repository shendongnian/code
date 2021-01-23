    public class Dog 
    {
    }
    public class Husky : Dog
    {
    }
    public class MyWrapper<T> : IMyWrapper<T> where T : class
    {
    }
    public interface IMyWrapper<out T> where T : class
    {
    }
