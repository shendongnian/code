    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Mvc;
    using System.Web.Security;
    public partial class views_html_form : System.Web.UI.Page
    {
    public static string UID()
    {
        MembershipUser currentUser;
        currentUser = Membership.GetUser();
        string UID = currentUser.UserName;
        return UID;
    }
    public static string PWD()
    {
        MembershipUser currentUser;
        currentUser = Membership.GetUser();
        string PWD = currentUser.GetPassword();
        return PWD;
    }
    public static void SelectRecord()
    {
        YourModel.Entities db = new YourModel.Entities(UID(), PWD());
        var query = from rows in db.Table_Name orderby rows.ID select rows;
       .....
