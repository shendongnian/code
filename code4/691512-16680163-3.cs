    public abstract class GenericBaseCopy<Src, Dst> where Dst : Src
    {
        private static List<Tuple<FieldInfo, FieldInfo>> _fieldsMap;
        static GenericBaseCopy()
        {
            _fieldsMap = new List<Tuple<FieldInfo, FieldInfo>>();
            foreach (FieldInfo customFI in typeof(Dst).GetFields())
                foreach (FieldInfo baseFI in typeof(Src).GetFields())
                    if (customFI.Name == baseFI.Name)
                        _fieldsMap.Add(new Tuple<FieldInfo, FieldInfo>(customFI, baseFI));
        }
        
        public static void Copy(Src baseClassInstance, Dst dstClassInstance)
        {
            foreach (Tuple<FieldInfo, FieldInfo> t in _fieldsMap)
                t.Item1.SetValue(dstClassInstance, t.Item2.GetValue(baseClassInstance));
        }
    }
