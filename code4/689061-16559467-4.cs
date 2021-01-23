	public object SelectedValue
	{
		get
		{
			if ((this.SelectedIndex != -1) && (this.dataManager != null))
			{
				object item = this.dataManager[this.SelectedIndex];
				return this.FilterItemOnProperty(item, this.valueMember.BindingField);
			}
			return null;
		}
		set
		{
			if (this.dataManager != null)
			{
				string bindingField = this.valueMember.BindingField;
				if (string.IsNullOrEmpty(bindingField))
				{
					throw new InvalidOperationException(SR.GetString("ListControlEmptyValueMemberInSettingSelectedValue"));
				}
				PropertyDescriptor property = this.dataManager.GetItemProperties().Find(bindingField, true);
				int num = this.dataManager.Find(property, value, true);
				this.SelectedIndex = num;
			}
		}
	}
