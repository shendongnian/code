    Type commonType = typeof(PointCommonInformation);
    
    foreach (PropertyInfo item in commonType.GetProperties())
    {
            object propertyObject = item.GetValue(pointCommonInfo, null);
            string propertyValue = propertyObject == null ? string.Empty : propertyObject.ToString();
            DGVPointCtrl.Rows[j].Cells[item.Name].Value = propertyValue;    
    }
