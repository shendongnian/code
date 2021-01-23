    public interface IDemoralizeBase
    {
        void Demoralize(Func<IDemoralize, bool> CustomDemoralization);
        void WriteModel(Func<IDemoralize, bool> Write);
    }
