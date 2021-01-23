	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.Diagnostics;
	namespace TestControls
	{
		class SimpleButton:Button
		{
			public bool IgnoreMouseEnter { get; set; }
			public SimpleButton()
			{
				this.IgnoreMouseEnter = false;
			}
			protected override void OnMouseEnter(EventArgs e)
			{
				Debug.Print("this.IgnoreMouseEnter = {0}", this.IgnoreMouseEnter);
				if (this.IgnoreMouseEnter == false)
				{
					base.OnMouseEnter(e);
				}
			}
		}
	}
