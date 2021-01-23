	using System;
	using System.Runtime.InteropServices;
	using System.Text;
	[Guid("3CD141F4-3C6A-11d2-BCAA-00C04FD929DB")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	interface IAutoCompleteDropDown
	{
		void GetDropDownStatus(out AutoCompleteDropDownFlags dwFlags, out StringBuilder wszString);
		void ResetEnumerator();
	}
