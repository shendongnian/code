	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	namespace UserControlExample {
		[ParseChildren(false)]
		public class TogglePanel : UserControl {
			private CheckBox cbToggleContent = new CheckBox();
			private Panel pnlContentPlaceholder = new Panel();
			public TogglePanel() {
				Load += OnLoad;
			}
			public bool Checked { get; set; }
			private void OnLoad(object sender, EventArgs eventArgs) {
				Controls.Add(cbToggleContent);
				Controls.Add(pnlContentPlaceholder);
				if (!IsPostBack) {
					cbToggleContent.Checked = Checked;
					pnlContentPlaceholder.Visible = Checked;
				}
	 
				cbToggleContent.AutoPostBack = true;
				cbToggleContent.CheckedChanged += (s, args) => {
					pnlContentPlaceholder.Visible = cbToggleContent.Checked;
				};
			}
			protected override void AddParsedSubObject(object obj) {
				pnlContentPlaceholder.Controls.Add((Control) obj);
			}
		}
	}
