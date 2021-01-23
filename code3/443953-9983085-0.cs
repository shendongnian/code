    public static class CloningExtensions
    {
        public static T Clone<T>(this T source)
        {
    //            var dcs = new DataContractSerializer(typeof(T), null, int.MaxValue, false, true, null);
            var dcs = new System.Runtime.Serialization
              .DataContractSerializer(typeof(T));
            using (var ms = new System.IO.MemoryStream())
            {
                dcs.WriteObject(ms, source);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                return (T)dcs.ReadObject(ms);
            }
        }
    }
