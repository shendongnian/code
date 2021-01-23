        String objectToXMLString(object o)
        {
            System.Type type = o.GetType();
            PropertyInfo[] piList = type.GetProperties();
            StringBuilder sb = new StringBuilder("<attributeList>");
            foreach (PropertyInfo pi in piList)
            {
                sb.Append("<attribute>");
                sb.Append("<name>" + pi.Name + "</name>");
                sb.Append("<value>" + pi.GetValue(o) + "</value>");
                sb.Append("<dataType>" + pi.PropertyType.Name + "</dataType>");
                sb.Append("</attribute>");
            }
            sb.Append("</attributeList>");
            return sb.ToString();
        }
