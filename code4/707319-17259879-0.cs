    public interface IExtension 
    {
        bool IsSerializable { get; }
    }
    public abstract class Extensible
    {
        public static bool ShouldSerializeExtensions = true;
        public IExtension Extension { get; set; }
        public bool ShouldSerializeExtension()
        {
            return ShouldSerializeExtensions &&
                   Extension != null &&
                   Extension.IsSerializable;
        }
    }
