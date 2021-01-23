	public partial class DeviceSnmpSettings : UserControl, INotifyPropertyChanged
	{
		private readonly List<Control> AuthenticationControls = new List<Control>(6);
		private readonly List<Control> PrivacyControls = new List<Control>(6);
		public event PropertyChangedEventHandler PropertyChanged;
		
		public DeviceSnmpSettings()
		{
			InitializeComponent();
			InitializeAuthControls();
			InitializePrivacyControls();
		}
		public DeviceSnmpSettings(Point location)
			: this()
		{
			Location = location;
		}
		//TODO: Move out into sub-user control?
		private void InitializeAuthControls()
		{
			AuthenticationControls.Add(lblAuthPassword);
			AuthenticationControls.Add(mskdTxtBxAuthPassword);
			AuthenticationControls.Add(lblAuthProtocol);
			AuthenticationControls.Add(cmbBxAuthProtocol);
			AuthenticationControls.Add(lblAuthPasswordConfirm);
			AuthenticationControls.Add(mskdTxtBxAuthPasswordConfirm);
		}
		//TODO: Move out into sub-user control?
		private void InitializePrivacyControls()
		{
			PrivacyControls.Add(lblPrivacyPassword);
			PrivacyControls.Add(mskdTxtBxPrivacyPassword);
			PrivacyControls.Add(lblPrivacyProtocol);
			PrivacyControls.Add(cmbBxPrivacyProtocol);
			PrivacyControls.Add(lblPrivacyPasswordConfirm);
			PrivacyControls.Add(mskdTxtBxPrivacyPasswordConfirm);
		}
		private bool SNMPv3Enabled
		{
			get { return chkBxSNMPv3.Checked; }
			set { chkBxSNMPv3.Checked = value; }
		}
		private SNMPV3Mode SecurityMode
		{
			get
			{
				SNMPV3Mode mode = SNMPV3Mode.NoAuthNoPriv;
				if (rdBtnAuthNoPriv.Checked)
					mode = SNMPV3Mode.AuthNoPriv;
				else if(rdBtnAuthPriv.Checked)
					mode = SNMPV3Mode.AuthPriv;
				return mode;
			}
			set
			{
				switch (value)
				{
					case SNMPV3Mode.NoAuthNoPriv:
						rdBtnNoAuthNoPriv.Checked = true;
						break;
					case SNMPV3Mode.AuthNoPriv:
						rdBtnAuthNoPriv.Checked = true;
						break;
					default:
						rdBtnAuthPriv.Checked = true;
						break;
				}
				OnSecurityModeChanged();
			}
		}
		protected virtual void OnSecurityModeChanged()
		{
			AuthenticationControls.ForEach(control => SetControlEnabledState(control, AuthenticationEnabled));
			PrivacyControls.ForEach(control => SetControlEnabledState(control, PrivacyEnabled));
			NotifyPropertyChanged("SecurityMode");
		}
		private void NotifyPropertyChanged(string property)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
		private bool AuthenticationEnabled
		{
			get
			{
				return SNMPv3Enabled && (SecurityMode == SNMPV3Mode.AuthPriv || SecurityMode == SNMPV3Mode.AuthNoPriv);
			}
		}
		private bool PrivacyEnabled
		{
			get { return SNMPv3Enabled && SecurityMode == SNMPV3Mode.AuthPriv; }
		}
		private void ChkBxSnmPv3OnCheckedChanged(object sender, EventArgs eventArgs)
		{
			SetControlEnabledStates();
		}
		private void SetControlEnabledStates()
		{
			snmpSettingsErrorProvider.Clear();
			foreach (Control control in grpBxSNMPv3.Controls)
			{
				//Check each of the lists for the control to prevent flickering.
				if (control != chkBxSNMPv3 && !AuthenticationControls.Contains(control) && !PrivacyControls.Contains(control))
					control.Enabled = SNMPv3Enabled;
			}
			//Need to validate that our radio button's checked state is reflected properly.
			AuthenticationControls.ForEach(control => SetControlEnabledState(control, AuthenticationEnabled));
			PrivacyControls.ForEach(control => SetControlEnabledState(control, PrivacyEnabled));
		}
		public void LoadFields(NetworkDiscovery networkDiscovery)
		{
			SNMPv3Enabled = networkDiscovery.Snmpv3Enabled;
			SecurityMode = networkDiscovery.SecurityMode;
			txtBxSNMPv3Username.Text = networkDiscovery.Username;
			mskdTxtBxAuthPassword.Text = networkDiscovery.AuthPassword;
			mskdTxtBxAuthPasswordConfirm.Text = networkDiscovery.AuthPassword;
			cmbBxAuthProtocol.SelectedItem = networkDiscovery.AuthProtocol.ToString();
			mskdTxtBxPrivacyPassword.Text = networkDiscovery.PrivacyPassword;
			mskdTxtBxPrivacyPasswordConfirm.Text = networkDiscovery.PrivacyPassword;
			cmbBxPrivacyProtocol.SelectedItem = networkDiscovery.PrivacyProtocol.ToString();
			SetControlEnabledStates();
		}
		private void SetControlEnabledState(Control control, bool enabled)
		{
			control.Enabled = enabled;
                        //Clear errors set on errorProvider when control is disabled.
			if (!control.Enabled)
				snmpSettingsErrorProvider.SetError(control, string.Empty);
		}
		private void rdBtnNoAuthNoPriv_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
				SecurityMode = SNMPV3Mode.NoAuthNoPriv;
		}
		private void rdBtnAuthNoPriv_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
				SecurityMode = SNMPV3Mode.AuthNoPriv;
		}
		private void rdBtnAuthPriv_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
				SecurityMode = SNMPV3Mode.AuthPriv;
		}
	}
