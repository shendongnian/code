	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	public class test_Page : Page
	{
			protected Repeater TestRepeater;
			protected override void OnInit(EventArgs e)
			{
					base.OnInit(e);
					String[] names = new String[] 
					{        
							"Alpha, John",
							"Altman, Mary", 
							"Asher, Cyril",
							"Bachman, Turner",
							"Beta, Rob",
							"Bexman, Norah",
							"Clark, Freddy"
					};
					List<_DispItem> l = new List<_DispItem>();
					for (int i = 0; i < names.Length; i++)
							l.Add(new _DispItem() { Name = names[i], IsFirstInGroup = (i == 0 || names[i - 1][0] != names[i][0]) });
					TestRepeater.DataSource = l;
					TestRepeater.DataBind();
			}
			private class _DispItem
			{
					public String Name { get; set; }
					public String Initial { get { return Name.Substring(0, 1); } }
					public bool IsFirstInGroup { get; set; }
			}
	}
