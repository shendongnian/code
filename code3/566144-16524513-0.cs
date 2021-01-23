    	internal static void DrawListBox(object sender, DevExpress.XtraEditors.ListBoxDrawItemEventArgs e)
		{
			e.Cache.DrawString(e.Item.ToString(), e.Appearance.Font, new SolidBrush(Color.White),
				e.Bounds, e.Appearance.GetStringFormat());
			e.Handled = true;
		}
