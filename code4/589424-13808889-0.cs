    var sb = new StringBuilder("XXX");
    if (skuACheckBox.Checked) {
        sb.Append("-A");
    }
    if (skuBCheckBox.Checked) {
        sb.Append("-B");
    }
    if (skuCCheckBox.Checked) {
        sb.Append("-C");
    }
    string skuWithSuffix = sb.ToString();
