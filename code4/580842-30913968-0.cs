            objCommonDD = new CommonDropDownBLL();
            objCommonDDEntity = new CommonDropdownEntity();
            //string strState=contextKey.ToString();
            string[] contextKeySplit = contextKey.Split('^');
            string strState = contextKeySplit[0].ToString();
            string strPin = contextKeySplit[1].ToString();
            objCommonDDEntity.TableName = "PCOM_PINCODES";
            objCommonDDEntity.DeleteField = "";
            objCommonDDEntity.TextField = "RTRIM(PIN_CITY_NAME) AS PC_DESC";
            objCommonDDEntity.ValueField = "DISTINCT PIN_CITY_CODE AS PC_CODE";
            objCommonDDEntity.StrCondition = " AND PIN_COUNTRY_CODE='IND' AND UPPER(PIN_CITY_NAME) LIKE UPPER('" + prefixText + "%') AND PIN_STATE_NAME='" + strState + "' AND PIN_CODE='" + strPin + "' ORDER BY PC_DESC";
            DataTable dtCity = new DataTable();
            dtCity = objCommonDD.GetData(objCommonDDEntity);
            string[] items = new string[dtCity.Rows.Count];
            int i = 0;
            for (i = 0; i < dtCity.Rows.Count; i++)
            {
                items.SetValue(dtCity.Rows[i]["PC_DESC"].ToString(), i);
            }
            return items;
        }
