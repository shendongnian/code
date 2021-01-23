    public abstract class GenericBaseCopy<Src, Dst> where Dst : Src
    {
        private static List<Tuple<FieldInfo, FieldInfo>> _fieldsMap;
        static GenericBaseCopy()
        {
            _fieldsMap = new List<Tuple<FieldInfo, FieldInfo>>();
            foreach (FieldInfo customFI in GetAllFields(typeof(Dst)))
                foreach (FieldInfo baseFI in GetAllFields(typeof(Src)))
                    if (customFI.Name == baseFI.Name)
                        _fieldsMap.Add(new Tuple<FieldInfo, FieldInfo>(customFI, baseFI));
        }
        private static List<FieldInfo> GetAllFields(Type t)
        {
            List<FieldInfo> res = new List<FieldInfo>();
            while (t != null)
            {
                foreach (FieldInfo fi in t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
                    if (!fi.IsLiteral)
                        res.Add(fi);
                t = t.BaseType;
            }
            return res;
        }
        
        public static void Copy(Src baseClassInstance, Dst dstClassInstance)
        {
            foreach (Tuple<FieldInfo, FieldInfo> t in _fieldsMap)
                t.Item1.SetValue(dstClassInstance, t.Item2.GetValue(baseClassInstance));
        }
    }
