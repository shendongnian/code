     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace Extensions
    {
        public static class ObjectExtension
        {
            public static string ToStringProperties(this object o)
            {
                return o.ToStringProperties(0);
            }
        public static string ToStringProperties(this object o, int level)
        {
            StringBuilder sb = new StringBuilder();
            string spacer = new String(' ', 2 * level);
            if (level == 0) sb.Append(o.ToString());
            sb.Append(spacer);
            sb.Append("{\r\n");
            foreach (PropertyInfo pi in o.GetType().GetProperties())
            {
            if (pi.GetIndexParameters().Length == 0)
            {
                sb.Append(spacer);
                sb.Append("  ");
                sb.Append(pi.Name);
                sb.Append(" = ");
                object propValue = pi.GetValue(o, null);
                if (propValue == null)
                {
                    sb.Append(" <null>");
                } else {
                    if (IsMyOwnType(pi.PropertyType))
                    {
                        sb.Append("\r\n");
                        sb.Append(((object)propValue).ToStringProperties(level + 1));
                    } else{
                        sb.Append(propValue.ToString());
                    }
                }
                sb.Append("\r\n");
            }
        }
        sb.Append(spacer);
        sb.Append("}\r\n");
        return sb.ToString();
    }
        private static bool IsMyOwnType(Type t) 
    {
        return (t.Assembly == Assembly.GetExecutingAssembly());
    }
    }
    }
