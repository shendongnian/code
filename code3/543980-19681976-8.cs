	IExcelLayer m_instance = null;
	...
	try
	{
		Assembly assembly = Assembly.Load("Utils.OfficeAutomation.Impl");
		Type excelType = assembly.GetType("Utils.OfficeAutomation.Impl.ExcelMagician");
		m_instance = (IExcelLayer) Activator.CreateInstance(excelType);
		
	}
	catch (Exception e)
	{
		throw new Exception("Couldn't load Excel assembly.")
	}
