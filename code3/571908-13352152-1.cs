	public CustomDataType GetSelectedtemsData(string[] parameterName, string fromTime, string toTime)
	{
		CustomDataType tempObj;		// *Rename this variable*
		List<double> valueList = new List<double>();
		List<string> timeStampList = new List<string>();
		for (counter = 0; counter < parameterName.Length; counter++)
		{
			tempObj = GetItemData(parameterName[counter], fromTime, toTime);
			valueList.AddRange(tempObj.arrayOfValue);
			timeStampList.AddRange(tempObj.arrayOfTimeStamp);
		}
		getSelectedItemsObj = new CustomDataType();
		getSelectedItemsObj.arrayOfValue = valueList.ToArray();
		getSelectedItemsObj.arrayOfTimeStamp = timeStampList.ToArray();
		return getSelectedItemsObj;
	}
