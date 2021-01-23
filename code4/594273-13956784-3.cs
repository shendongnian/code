    Int32 Val = 0;
    dynamic conditions = new Hashtable();
    conditions.Add("miap", ViewState["miap_txt"]);
    conditions.Add("pocode", ViewState["po_txt "]);
    foreach (string name in conditions.Keys)
    {
        if (Int32.TryParse(conditions[name].ToString(), out Val))
        {
            //Your Logic for int
        }
        else
        {
            //Your Logic for String
        }
    }
