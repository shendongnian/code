    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.compareValidator.ID = string.Format("{0}_{1}", this.ID, this.compareValidator.ID);
        if (this.ClientIDMode == ClientIDMode.Static)
        {
            this.textBox.ID = this.ID;
        }
        this.label.Attributes.Add("for", this.textBox.ClientID);
        this.label.InnerHtml = string.Format("{0}:{1}", this.Label, EmitRequiredSup());
        this.requiredFieldValidator.Visible = this.IsRequired;
        this.regexValidator.Visible = (this.Regexes != null);
        if (this.regexValidator.Visible)
        {
            var regexes = string.Join("|", this.Regexes);
            this.regexValidator.ValidationExpression = regexes;
        }
        this.compareValidator.Visible = !string.IsNullOrEmpty(this.ControlToCompare);
        this.rangeValidator.Visible = !string.IsNullOrEmpty(this.RangeMinimumValue);
        this.requiredFieldValidator.ControlToValidate = this.textBox.ID;
        this.regexValidator.ControlToValidate = this.textBox.ID;
        this.compareValidator.ControlToValidate = this.ID;
        this.customValidator.ControlToValidate = this.textBox.ID;
        this.rangeValidator.ControlToValidate = this.textBox.ID;
    }
