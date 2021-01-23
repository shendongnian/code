    internal static class ExtensionMethods
	{
		public static List<XElement> Find(this XElement _objXElement, string _strFindXName)
		{
			List<XElement> _lsXElementsFound = new List<XElement>();
			try
			{
				List<XElement> _lsXElementsBundle = new List<XElement>();
				RecursiveSearch(_objXElement, _strFindXName, ref _lsXElementsBundle);
				if (_lsXElementsBundle != null && _lsXElementsBundle.Count > 0)
				{
					foreach (XElement _objCurrentXElement in _lsXElementsBundle)
					{
						if (_objCurrentXElement != null)
						{
							if (!string.IsNullOrEmpty(_objCurrentXElement.Value))
							{
								_lsXElementsFound.Add(_objCurrentXElement);
							}
							else
							{
								_objCurrentXElement.Value = string.Empty;
								_lsXElementsFound.Add(_objCurrentXElement);
							}
						}
					}
				}
			}
			catch (Exception _objException)
			{
				_lsXElementsFound = new List<XElement>();
				string _strDescription = NLOG.Utility.FormatEvent(MethodBase.GetCurrentMethod()
					, _objException.Message);
				NLOG.Log.Error(_strDescription);
			}
			return _lsXElementsFound;
		}
		#region "SUPPORT"
		private static void RecursiveSearch(XElement _objXElement, string _strFindXName
			, ref List<XElement> _lsOfXElementsFound)
		{
			try
			{
				if (_objXElement != null && !string.IsNullOrEmpty(_strFindXName)
					&& _lsOfXElementsFound != null)
				{
					if (_objXElement.Name == _strFindXName)
					{
						_lsOfXElementsFound.Add(_objXElement);
					}
					else
					{
						foreach (XElement _objCurrentXElement in _objXElement.Elements())
						{
							RecursiveSearch(_objCurrentXElement, _strFindXName, ref _lsOfXElementsFound);
						}
					}
				}
			}
			catch (Exception _objException)
			{
				string _strDescription = NLOG.Utility.FormatEvent(MethodBase.GetCurrentMethod()
					, _objException.Message);
				NLOG.Log.Error(_strDescription);
			}
		}
		#endregion
	}
