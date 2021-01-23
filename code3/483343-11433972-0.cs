private void PropertyGrid_Resize(object sender, EventArgs e)
{
  foreach (Control control in (sender as PropertyGrid).Controls)
    if (control.GetType().Name == "DocComment")
    {
      FieldInfo fieldInfo = control.GetType().BaseType.GetField("userSized",
        BindingFlags.Instance |
        BindingFlags.NonPublic);
      fieldInfo.SetValue(control, true);
      control.Width = (sender as PropertyGrid).Width;
      foreach (Control ctrl in control.Controls)
      {
          ctrl.Width = control.Width;
      }
      return;
    }            
}
