    public static string RenderView(string path, object data)
    {
        Page pageHolder = new Page();
        UserControl viewControl = (UserControl) pageHolder.LoadControl(path);
        if (data != null)
        {
            Type viewControlType = viewControl.GetType();            
            FieldInfo field = viewControlType.GetField("Data");
            if (field != null)
            {
                field.SetValue(viewControl, data);
            }
            else
            {
                throw new Exception("View file: " + path + " does not have a public Data property");
            }
        }
        pageHolder.Controls.Add(viewControl);
        StringWriter output = new StringWriter();
        HttpContext.Current.Server.Execute(pageHolder, output, false);
        return output.ToString();
    }
