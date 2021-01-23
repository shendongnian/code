	using System;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	[ComImport]
	[Guid("00bb2762-6a77-11d0-a535-00c04fd7d062")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CoClass(typeof(IAutoCompleteClass))]
	interface IAutoComplete
	{
		void Init(HandleRef hwndEdit, IEnumString punkACL, string pwszRegKeyPath, string pwszQuickComplete);
		void Enable(bool fEnable);
	}
