            if (valueObj != "")
            {
                if (strCurrentDatatype.ToLower().Contains("int"))
                {
                    valueObj = Convert.ToInt32(valueObj);
                }
                else if (strCurrentDatatype.ToLower().Contains("decimal"))
                {
                    valueObj = Convert.ToDecimal(valueObj);
                }
                else if (strCurrentDatatype.ToLower().Contains("double") || strCurrentDatatype.ToLower().Contains("real"))
                {
                    valueObj = Convert.ToDouble(valueObj);
                }
                else if (strCurrentDatatype.ToLower().Contains("string"))
                {
                    valueObj = Convert.ToString(valueObj);
                }
                else
                {
                    valueObj = valueObj.ToString();
                }
            }
            else
            {
                valueObj = null;
            }
            return valueObj;
        }
