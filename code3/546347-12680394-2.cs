    interface IGetSettable
    {
        public void SetValue(
            Object obj,
            Object value,
            Object[] index);
        public Object GetValue(
            Object obj,
            Object[] index);
    }
    public class ParameterInfoGS : IGetSettable
    {
        protected ParameterInfo pi;
        public ParameterInfoExtra(ParameterInfo _pi)
        {
            pi = _pi;
        }
        public void SetValue(
            Object obj,
            Object value,
            Object[] index) {pi.SetValue(obj, value, index);}
        public Object GetValue(
            Object obj,
            Object[] index) {return pi.GetValue(obj, index);}
    }
    public class FieldInfoGS : IGetSettable
    {
        protected FieldInfo pi;
        public FieldInfoExtra(FieldInfo _pi)
        {
            pi = _pi;
        }
        public void SetValue(
            Object obj,
            Object value,
            Object[] index) {pi.SetValue(obj, value, index);}
        public Object GetValue(
            Object obj,
            Object[] index) {return pi.GetValue(obj, index);}
    }
    public static class AssemblyExtension
    {
        public static IGetSettable[] GetParametersAndFields(this Type t)
        {
            List<IGetSettable> retList = new List<IGetSettable>();
            foreach(ParameterInfo pi in t.GetParameters())
                retList.Add(new ParameterInfoExtra(pi));
            foreach(FieldInfo fi in t.GetFields())
                retList.Add(new FieldInfoExtra(fi));
            return retList.ToArray();
        }
    }
