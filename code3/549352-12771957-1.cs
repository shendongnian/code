    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class stackoverflow_12761515 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("attribute_id");
            for (int i = 0; i < 5; i++)
            {
                DataRow dr = dt.NewRow();
                dr["attribute_id"] = i + 1;
                dr["name"] = "item " + i + 1;
                dt.Rows.Add(dr);
            }
            lvAttributes.DataSource = dt;
            lvAttributes.DataBind();
            //BindListBox();
        }
    }
    private void BindListBox(ListBox lb)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("value");
        dt.Columns.Add("tag_id");
        for (int i = 0; i < 5; i++)
        {
            DataRow dr = dt.NewRow();
            dr["tag_id"] = i + 1;
            dr["value"] = "value " + i + 1;
            dt.Rows.Add(dr);
        }
        //ListBox lb = (ListBox)lvAttributes.FindControl("lbAttributeTags");
        lb.DataSource = dt;
        lb.DataTextField = "value";
        lb.DataValueField = "tag_id";
        lb.DataBind();
    }
    protected void lvAttributes_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListBox lb = (ListBox)e.Item.FindControl("lbAttributeTags");
        BindListBox(lb);
    }
    protected void btnSample_Click(object sender, EventArgs e)
    {
        lblDisplay.Text = string.Empty;
        for (int i = 0; i < lvAttributes.Items.Count; i++)
        {
            ListBox lb = (ListBox)lvAttributes.Items[i].FindControl("lbAttributeTags");
            if (lb.SelectedIndex != -1)
            {
                lblDisplay.Text += lb.SelectedItem.Text + "\n";
            }
            
        }
    }
    protected void btnInsideLV_Click(object sender, CommandEventArgs e)
    {
        int selectedRow = Convert.ToInt32(e.CommandArgument.ToString());
        ListBox lbCurrent = (ListBox)lvAttributes.Items[selectedRow - 1].FindControl("lbAttributeTags");
        if (lbCurrent.SelectedIndex != -1)
        {
            lblSelectedRowValue.Text = "Row selected is : " + selectedRow + " and list item is : " + lbCurrent.SelectedItem.Text;
        }
        else
        {
            lblSelectedRowValue.Text = "no item selected";
        }
    }
