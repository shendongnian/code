	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	using System.ComponentModel;
	using System.Drawing;
	namespace MyCustomControls
	{
		public class PagedPanel : TabControl
		{
			//------------------------------------------------------------------------------------------------
			public PagedPanel()
			{
				base.Multiline = true;
				base.Appearance = TabAppearance.Buttons;
				base.ItemSize = new Size(0, 1);
				base.SizeMode = TabSizeMode.Fixed;
				base.TabStop = false;
			}
			//------------------------------------------------------------------------------------------------
			protected override void WndProc(ref Message m)
			{
				// Hide tabs by trapping the TCM_ADJUSTRECT message
				if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
				else base.WndProc(ref m);
			}
			//------------------------------------------------------------------------------------------------
			protected override void OnKeyDown(KeyEventArgs ke)
			{
				// Block Ctrl+Tab and Ctrl+Shift+Tab hotkeys
				if (ke.Control && ke.KeyCode == Keys.Tab)
					return;
				base.OnKeyDown(ke);
			}
			//------------------------------------------------------------------------------------------------
			[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[DefaultValue(true)]
			public new bool Multiline
			{
				get { return base.Multiline; }
				set { base.Multiline = value; Invalidate(); }
			}
			//------------------------------------------------------------------------------------------------
			[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)
			, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[DefaultValue(TabAppearance.Buttons)]
			public new TabAppearance Appearance
			{
				get { return base.Appearance; }
				set { base.Appearance = value; Invalidate(); }
			}
			//------------------------------------------------------------------------------------------------
			[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)
			, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[DefaultValue(typeof(Size), "0, 1")]
			public new Size ItemSize
			{
				get { return base.ItemSize; }
				set { base.ItemSize = value; Invalidate(); }
			}
			//------------------------------------------------------------------------------------------------
			[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)
			, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[DefaultValue(TabSizeMode.Fixed)]
			public new TabSizeMode SizeMode
			{
				get { return base.SizeMode; }
				set { base.SizeMode = value; Invalidate(); }
			}
			//------------------------------------------------------------------------------------------------
			[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)
			, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			public new TabPageCollection TabPages
			{
				get { return base.TabPages; }
			}
			//------------------------------------------------------------------------------------------------
			[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[DefaultValue(false)]
			public new bool TabStop
			{
				get { return base.TabStop; }
				set { base.TabStop = value; Invalidate(); }
			}
			//------------------------------------------------------------------------------------------------
			public TabPageCollection Pages
			{
				get { return base.TabPages; }
			}
			//------------------------------------------------------------------------------------------------
		}
	}
