		/// <summary>
		/// Search and Find Registry Function
		/// </summary>
		public static string SearchRegistry(string dllName)
		{
			//Open the HKEY_CLASSES_ROOT\CLSID which contains the list of all registered COM files (.ocx,.dll, .ax) 
			//on the system no matters if is 32 or 64 bits.
			RegistryKey t_clsidKey = Registry.ClassesRoot.OpenSubKey("CLSID");
			//Get all the sub keys it contains, wich are the generated GUID of each COM.
			foreach (object subKey_loopVariable in t_clsidKey.GetSubKeyNames.ToList) {
				subKey = subKey_loopVariable;
				//For each CLSID\GUID key we get the InProcServer32 sub-key .
				RegistryKey t_clsidSubKey = Registry.ClassesRoot.OpenSubKey("CLSID\\" + subKey + "\\InProcServer32");
				if ((t_clsidSubKey != null)) {
					//in the case InProcServer32 exist we get the default value wich contains the path of the COM file.
					string t_valueName = (from value in t_clsidSubKey.GetValueNames()where string.IsNullOrEmpty(value))(0).ToString;
					//Now gets the value.
					string t_value = t_clsidSubKey.GetValue(t_valueName).ToString;
					//And finaly if the value ends with the name of the dll (include .dll) we return it
					if (t_value.EndsWith(dllName)) {
						return t_value;
					}
				}
			}
			//if not exist, return nothing
			return null;
		}
