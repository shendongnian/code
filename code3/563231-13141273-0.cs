    	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Runtime.InteropServices;
	using System.Reflection;
	namespace MovableForm
	{
		class winapi
		{
			public static void moveWindow(System.Windows.Forms.Form form){
				SetWindowPos(form.Handle, (IntPtr) HWNDPOS.HWND_TOPMOST, form.Left + 10, form.Top + 10, form.Width - 20, form.Height - 20, (uint)SWP.SWP_SHOWWINDOW);
			}
			public static void setStyle(System.Windows.Forms.Form frm)
			{
				uint oldStyle = getStyle(frm);
				uint newStyle = (uint)(
								WINSTYLES.WS_OVERLAPPED | WINSTYLES.WS_POPUP | WINSTYLES.WS_VISIBLE | 
								//WINSTYLES.WS_SYSMENU |  // add if you need a X to close
								WINSTYLES.WS_CAPTION | WINSTYLES.WS_BORDER | //WINSTYLES.WS_DLGFRAME | WINSTYLES.WS_MAXIMIZEBOX |
								WINSTYLES.WS_POPUPWINDOW);
				int iRet = SetWindowLong(frm.Handle, (int)GWL.GWL_STYLE, (int)newStyle);
				//if returned iRet is zero we got an error
				int newExStyle = GetWindowLong(frm.Handle, (int)GWL.GWL_EXSTYLE);
				newExStyle = (int)((uint)newExStyle - (uint) WINEXSTYLES.WS_EX_CAPTIONOKBTN); //remove OK button
				iRet = SetWindowLong(frm.Handle, (int)GWL.GWL_EXSTYLE, (int)newExStyle);
				moveWindow(frm);
				frm.Refresh();
			}
			//great stuff by http://ideas.dalezak.ca/2008/11/enumgetvalues-in-compact-framework.html
			public static IEnumerable<Enum> GetValues(Enum enumeration)
			{
				List<Enum> enumerations = new List<Enum>();
				foreach (FieldInfo fieldInfo in enumeration.GetType().GetFields(
					  BindingFlags.Static | BindingFlags.Public))
				{
					enumerations.Add((Enum)fieldInfo.GetValue(enumeration));
				}
				return enumerations;
			}
    ...
