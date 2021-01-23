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
    public class ParameterInfoExtra : IGetSettable
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
    public class FieldInfoExtra : IGetSettable
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
