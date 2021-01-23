	class TextBoxIM: TextBox{
		public static TextBox tb;
		protected override void OnGotFocus (EventArgs e)
		{
			tb=this;
			base.OnGotFocus (e);
		}
	}
    ...
	private void btnOK_Click (object sender, System.EventArgs e)
	{	 
		string sName="";
		foreach(Control c in this.Controls){
			if (c.GetType()==typeof(TextBoxIM)){
				sName=c.Name;
				break; //we only need one instance to get the value
			}
		}
		MessageBox.Show("Last textbox='"+sName+"'");
        }
