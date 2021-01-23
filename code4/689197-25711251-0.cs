    using System.Web.UI;
    
    public class ReflectionHelper
    {
    /// <summary>
    /// Check Control for match on ID and recursively check all Children for match on ID.
    /// </summary>
    /// <param name="ParentControl"></param>
    /// <param name="ControlId"></param>
    /// <returns>Control if found, null if not found</returns>
    /// /// <remarks>Jason Williams | 9/7/2014 | webprogrammerguy.com</remarks>
    public static Control FindControlRecursive(Control ParentControl, string ControlId)
    {
	    if (ParentControl.ID == ControlId) {
		    return ParentControl;
	    }
	    foreach (Control Ctl in ParentControl.Controls) {
		    Control FoundCtl = FindControlRecursive(Ctl, ControlId);
		    if ((FoundCtl != null)) {
			    return FoundCtl;
		    }
	    }
	    return null;
    }
    /// <summary>
    /// Check Control for match on ID and recursively check all Children for match on ID.  Attempt to Invoke() Control method.
    /// </summary>
    /// <param name="ParentControl"></param>
    /// <param name="ControlId"></param>
    /// <param name="MethodName"></param>
    /// <param name="parameters"></param>
    /// <returns>bool true if executed, bool false if error or not executed</returns>
    /// /// <remarks>Jason Williams | 9/7/2014 | webprogrammerguy.com</remarks>
    public static bool FindControlRecursiveAndInvokeMethod(Control ParentControl, string ControlId, string MethodName, object[] parameters)
    {
        var ctrl = FindControlRecursive(ParentControl, ControlId);
        if (ctrl != null)
        {
            try
            {
                MethodInfo[] ctrlMethods = ctrl.GetType().GetMethods();
                foreach (MethodInfo method in ctrlMethods)
                {
                    if (method.Name == MethodName)
                    {
                        method.Invoke(ctrl, parameters);
                        return true;
                    }
                }
                //return false;
            }
            catch (System.Exception)
            {
                //return false;
            }
        }
        else
        {
            //return false;
        }
        return false;
    }
    /// <summary>
    /// Check Control for match on ID and recursively check all Children for match on ID.  Attempt to set SetValue() on Control property.
    /// </summary>
    /// <param name="ParentControl"></param>
    /// <param name="ControlId"></param>
    /// <param name="PropertyName"></param>
    /// <param name="value"></param>
    /// <returns>bool true if executed, bool false if error or not executed</returns>
    /// /// <remarks>Jason Williams | 9/7/2014 | webprogrammerguy.com</remarks>
    public static bool FindControlRecursiveAndSetPropertyValue(Control ParentControl, string ControlId, string PropertyName, string value)
    {
        var ctrl = FindControlRecursive(ParentControl, ControlId);
        if (ctrl != null)
        {
            try
            {
                PropertyInfo[] ctrlProperties = ctrl.GetType().GetProperties();
                foreach (PropertyInfo property in ctrlProperties)
                {
                    if (property.Name == PropertyName)
                    {
                        property.SetValue(ctrl, value, new object[0]);
                        return true;
                    }
                }
                //return false;
            }
            catch (System.Exception)
            {
                //return false;
            }
        }
        else
        {
            //return false;
        }
        return false;
    }
    /// <summary>
    /// Check Control for match on ID and recursively check all Children for match on ID.  Attempt to set SetValue() on Control property.
    /// </summary>
    /// <param name="ParentControl"></param>
    /// <param name="ControlId"></param>
    /// <param name="PropertyName"></param>
    /// <param name="value"></param>
    /// <returns>bool true if executed, bool false if error or not executed</returns>
    /// <remarks>Jason Williams | 9/7/2014 | webprogrammerguy.com</remarks>
    public static bool FindControlRecursiveAndSetPropertyValue(Control ParentControl, string ControlId, string PropertyName, int value)
    {
        var ctrl = FindControlRecursive(ParentControl, ControlId);
        if (ctrl != null)
        {
            try
            {
                PropertyInfo[] ctrlProperties = ctrl.GetType().GetProperties();
                foreach (PropertyInfo property in ctrlProperties)
                {
                    if (property.Name == PropertyName)
                    {
                        property.SetValue(ctrl, value, new object[0]);
                        return true;
                    }
                }
                //return false;
            }
            catch (System.Exception)
            {
                //return false;
            }
        }
        else
        {
            //return false;
        }
        return false;
    }
    }
