    HtmlGenericControl hdn_sal_result = new HtmlGenericControl("input");
    hdn_sal_result.Attributes.Add("id", "hdn_give_rr");
    hdn_sal_result.Attributes.Add("name", "hdn_give_rr");
    hdn_sal_result.Attributes.Add("type", "hidden");
    hdn_sal_result.Attributes.Add("value", ((99 * int.Parse(Session["secret"].ToString())) + 761).ToString());
    
    HtmlGenericControl hdn_sal_h = new HtmlGenericControl("input");
    hdn_sal_h.Attributes.Add("id", "hdn_givel_h");
    hdn_sal_h.Attributes.Add("name", "hdn_give_h");
    hdn_sal_h.Attributes.Add("type", "hidden");
    hdn_sal_h.Attributes.Add("value", role_h.Hash((int.Parse(Session["secret"].ToString()) - 55).ToString(), "SHA512", null));
