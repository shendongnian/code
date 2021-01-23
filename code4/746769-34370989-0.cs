    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
        public static string GetFullTableName(this Type t)
        {
            string exp = "[{0}].[{1}]";
            if (Attribute.IsDefined(t, typeof(TableAttribute)))
            {
                var attr = (TableAttribute)t.GetCustomAttributes(typeof(TableAttribute), false).First();
                return string.Format(exp, attr.Schema, attr.Name);
            }
            else
            {
                return string.Format("[dbo].[{0}]", t.Name);
            }
        }
