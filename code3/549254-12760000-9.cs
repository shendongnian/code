	using System;
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Windows.Forms;
	public class MyTextBox : TextBox
	{
		IAutoComplete2 autoComplete;
		IAutoCompleteDropDown autoCompleteDropDown;
		public bool IsDroppedDown
		{
			get
			{
				if (autoCompleteDropDown == null)
					return false;
				AutoCompleteDropDownFlags dwFlags;
				StringBuilder wszString;
				autoCompleteDropDown.GetDropDownStatus(out dwFlags, out wszString);
				return (dwFlags & AutoCompleteDropDownFlags.Visible) != AutoCompleteDropDownFlags.None;
			}
		}
		protected override void CreateHandle()
		{
			base.CreateHandle();
			autoComplete = (IAutoComplete2)new IAutoComplete();
			autoCompleteDropDown = (IAutoCompleteDropDown)autoComplete;
			autoComplete.SetOptions(AutoCompleteOptions.AutoSuggest);
			autoComplete.Init(new HandleRef(this, this.Handle), new EnumString(new string[] { "Administrator", "Clerk" }), null, null);
		}
		protected override void DestroyHandle()
		{
			ReleaseAutoComplete();
			base.DestroyHandle();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				ReleaseAutoComplete();
			}
			base.Dispose(disposing);
		}
		protected override bool IsInputKey(Keys keyData)
		{
			return base.IsInputKey(keyData) || ((keyData & ~Keys.Shift) == Keys.Enter && IsDroppedDown);
		}
		void ReleaseAutoComplete()
		{
			if (autoComplete != null)
			{
				Marshal.ReleaseComObject(autoComplete);
				autoComplete = null;
				autoCompleteDropDown = null;
			}
		}
	}
