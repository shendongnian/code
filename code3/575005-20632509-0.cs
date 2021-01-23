    public override string FormatErrorMessage(string name)
    {
        EnsureLegalLengths();
        string format = ((this.MinimumLength != 0) && !base.CustomErrorMessageSet) ? DataAnnotationsResources.StringLengthAttribute_ValidationErrorIncludingMinimum : base.ErrorMessageString;
        return String.Format(CultureInfo.CurrentCulture, format, new object[] { name, MaximumLength, MinimumLength });
    }
