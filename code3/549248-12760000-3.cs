	using System;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	[Guid("EAC04BC0-3791-11d2-BB95-0060977B464C")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	interface IAutoComplete2
	{
		void Init(HandleRef hwndEdit, IEnumString punkACL, string pwszRegKeyPath, string pwszQuickComplete);
		void Enable(bool fEnable);
		void SetOptions(AutoCompleteOptions dwFlag);
		AutoCompleteOptions GetOptions();
	};
