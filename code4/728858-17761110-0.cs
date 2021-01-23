    public class Helper
    {
        public static bool IsNull(object o, params string[] prop)
        {
            if (o == null)
                return true;
            var v = o;
            foreach (string s in prop)
            {
                PropertyInfo pi = v.GetType().GetProperty(s); //Set flags if not only public props
                v = (pi != null)? pi.GetValue(v, null) : null;
                if (v == null)
                    return true;                                
            }
            return false;
        }
    }
        //In use
        isNull = Helper.IsNull(p, "ContactPerson", "TheCity");
