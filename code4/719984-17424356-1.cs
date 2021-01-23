       private void DisableControls(System.Web.UI.Control c)
        {
           Type type = c.GetType();
            PropertyInfo prop = type.GetProperty("Enabled");
            if ((prop != null))
            {
                prop.SetValue(c, false, null);
            }
        }
