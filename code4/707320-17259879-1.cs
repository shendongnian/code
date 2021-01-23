    public class A : Extensible
    {
        List<B> b { get; set; }
        C c { get; set; }
    }
    public class B  : Extensible
    { 
        int d { get; set; }
    }
    public class C  : Extensible
    {
        List<int> e { get; set; }
    }
    public class ExtensionA : IExtension
    {
        bool IsSerializable { get { return true; } }
        int extra { get; set; }
    }
    public class ExtensionB : IExtension
    {
        bool IsSerializable { get { return true; } }
        float extra { get; set; }
        void something();
    }
    public class ExtensionC : IExtension
    {
        bool IsSerializable { get { return true; } }
        float extra { get; set; }
    }
