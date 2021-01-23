        String objectToXML(object o)
        {
            String sXML="";
            System.Type type = o.GetType();
            PropertyInfo[] piList = type.GetProperties();
            sXML += "<attributeList>";
            foreach (PropertyInfo pi in piList)
            {
                sXML += "<attribute>";
                sXML += "<name>" + pi.Name + "</name>";
                sXML += "<value>" + pi.GetValue(o) + "</value>";
                sXML += "<dataType>" + pi.PropertyType.Name + "</dataType>";
                sXML += "</attribute>";
            }
            sXML += "</attributeList>";
            return sXML;
        }
