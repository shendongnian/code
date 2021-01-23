    interface IFile<out T1, out T2> where T1 : IMyInterface where T2 : IMyInterface
    {
        Int64 prop1 { get; set; }
        T1 t1 { get; }
        T2 t2 { get; }
    }
