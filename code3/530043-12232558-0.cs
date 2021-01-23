    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using HCA_QualityModel;
    public partial class Admin : System.Web.UI.Page
    {
    static HCA_QualityEntities database = new HCA_QualityEntities();
       protected void Page_Load(object sender, EventArgs e)
    {
        //bind the gridview on intial page load
        if (!Page.IsPostBack) bindGridViewData();
    }
    protected void bindGridViewData()
    {
     static object grvMachinesQuery = (from m in database.Machines
                                      from d in database.Workcenters
                                      where m.WorkcenterFK == d.id
                                      select
                                          new { id = m.id, MachineName = m.MachineName,  WorkCenterFK = d.WorkCenterName });
        //Data binds for gridviews and ddl's
        grvMachines.DataSource = grvMachinesQuery;
        grvWorkCenters.DataSource = (from w in database.Workcenters select w);
        grvUsers.DataSource = (from u in database.Users select u);
        ddlAddDept.DataSource = grvWorkCenters.DataSource;
        ddlAddDept.DataValueField = "id";
        ddlAddDept.DataTextField = "WorkCenterName";
        DataBind();
    }
    //Adds new data to the db, then rebinds the griviews to the db
    #region Submit Buttons
    protected void btnSubmitMachine_Click(object sender, EventArgs e)
    {
        //add new machine to the database
        Machine temp = new Machine();
        temp.MachineName = txtAddMachine.Text;
        temp.WorkcenterFK = Int32.Parse(ddlAddDept.SelectedValue);
        database.Machines.AddObject(temp);
        database.SaveChanges();
        bindGridViewData();
    }
    protected void btnSubmitDept_Click(object sender, EventArgs e)
    {
        //add new workcenter to database
        Workcenter temp = new Workcenter();
        temp.WorkCenterName = txtAddDept.Text;
        database.Workcenters.AddObject(temp);
        database.SaveChanges();
        bindGridViewData();
    }
    protected void btnUserSubmit_Click(object sender, EventArgs e)
    {
        //add new user to the database
        HCA_QualityModel.User temp = new User();
        temp.Username = txtAddUser.Text;
        temp.Password = txtAddPassword.Text;
        database.Users.AddObject(temp);
        database.SaveChanges();
        bindGridViewData();
    }
    #endregion
    //Handles Updating, editing, and deleting Gridview Controls
    #region Gridview machines
    protected void grvMachines_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DropDownList temp = (DropDownList)(e.Row.FindControl("ddlDept"));
        if (temp != null)
        {
            temp.DataSource = (from w in database.Workcenters select w);
            temp.DataTextField = "WorkCenterName";
            temp.DataValueField = "id";
            temp.DataBind();
        }
    }
    protected void grvMachines_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Int32.Parse(((Label)grvMachines.Rows[e.RowIndex].FindControl("lblId") as Label).Text);
        database.Machines.DeleteObject(((Machine)(from m in database.Machines where m.id == id select m).Single()));
        database.SaveChanges();
        bindGridViewData();
    }
    protected void grvMachines_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvMachines.EditIndex = -1;
        bindGridViewData();
    }
    protected void grvMachines_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvMachines.EditIndex = e.NewEditIndex;
        bindGridViewData();
    }
    protected void grvMachines_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Gridviews have no data on postback from events, rebinding looses the selected values from edit mode.
        bindGridViewData();
        DropDownList dept = (DropDownList)grvMachines.Rows[grvMachines.EditIndex].FindControl("ddlDept");
        TextBox name = (TextBox)grvMachines.Rows[grvMachines.EditIndex].FindControl("txtMachine");
        Int32 id = (Convert.ToInt32(((Label)grvMachines.Rows[grvMachines.EditIndex].FindControl("lblId")).Text));
        //Working Code to update the database, recieving incorrect data from controls due to rebinding 
        HCA_QualityEntities database = new HCA_QualityEntities();
        Machine temp = (from m in database.Machines where m.id == id select m).First();
        temp.MachineName = (name.Text);
        temp.WorkcenterFK = Int32.Parse(dept.SelectedValue);
        database.SaveChanges();
        grvMachines.EditIndex = -1;
        bindGridViewData();
    }
    #endregion
}
