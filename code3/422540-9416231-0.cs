    public interface IOld
    {
        void Meth1();
        [Obsolete("Use Meth22 instead.")]
        double Meth2(int input);
        float Meth22(int input);
    } 
