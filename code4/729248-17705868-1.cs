    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Configuration;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data;
    
    public partial class test : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["WildfireOperationsResearch"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                dvProposal_DataRebind();
            }
        }
    
        
        
        protected void LoadProposalStatusDropDownList()
        {
            DropDownList ProposalStatusList = (DropDownList)this.dvProposal.FindControl("ddlProposalStatus");
            string SelectString = "select ProposalStatus from ProposalStatus order by ProposalStatus";
            OleDbConnection MyConnection = new OleDbConnection(connectionString);
            OleDbDataAdapter MyDataAdapter = new OleDbDataAdapter(SelectString, MyConnection);
            DataSet MyDataSet = new DataSet();
           
                MyDataAdapter.Fill(MyDataSet);
                ProposalStatusList.DataSource = MyDataSet;
    
                
                
                ProposalStatusList.DataBind();
    
                if (dvProposal.CurrentMode == DetailsViewMode.Edit)
                {
                    DataRowView drv=(DataRowView)this.dvProposal.DataItem;
    
                    ProposalStatusList.Items.FindByValue(drv.Row[4].ToString()).Selected = true;
                }
    
            
        }
    
        protected void dvProposal_DataRebind()
        {
                   
            string SelectString = "select ProposalNo,ProposalCode, ProposalTitle, YearSubmitted, ProposalStatus, ProposalLink " +
                "from Proposal where ProposalNo=64" ;
            OleDbConnection MyConnection = new OleDbConnection(connectionString);
            OleDbDataAdapter MyDataAdapter = new OleDbDataAdapter(SelectString, MyConnection);
            DataSet MyDataSet = new DataSet();
            
                MyDataAdapter.Fill(MyDataSet);
    
                //load into detail view
            
                dvProposal.DataSource = MyDataSet;
                dvProposal.AutoGenerateEditButton = true;
                dvProposal.AutoGenerateDeleteButton = true;
                dvProposal.AutoGenerateInsertButton = true;
                
                dvProposal.DataBind();
    
                
            
        }
    
        
    
        protected void dvProposal_OnDataBound(Object sender, EventArgs e)
        {
            if (this.dvProposal.CurrentMode != DetailsViewMode.ReadOnly)
            {
                LoadProposalStatusDropDownList();
                ((TextBox)dvProposal.Rows[0].Cells[1].Controls[0]).Enabled = false;
    
            }
    
        }
        
        protected void dvProposal_OnModeChanging(Object sender, DetailsViewModeEventArgs e)
        {
            
    
            dvProposal.ChangeMode(e.NewMode);
    
            dvProposal_DataRebind();
            
    
            
            
        }
    
        protected void dvProposal_OnItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
    
            string proposalCode = e.Values[1].ToString();
            string proposalTitle = e.Values[2].ToString();
            string yearSubmitted = e.Values[3].ToString();
    
            //give me a NullReferenceException. Cannot find the DropDownList control in the DetailView. 
            string proposalStatus = ((DropDownList)dvProposal.Rows[4].Cells[1].FindControl("ddlProposalStatus")).SelectedValue;
            
            string proposalLink = e.Values[4].ToString();
    
            string insertString = " insert into Proposal (ProposalCode, ProposalTitle, YearSubmitted, ProposalStatus, ProposalLink) " +
                "values('" + proposalCode + "','" + proposalTitle + "'," + yearSubmitted + ",'" + proposalStatus + "','" + proposalLink + "')";
                
               
            OleDbConnection MyConnection = new OleDbConnection(connectionString);
            OleDbCommand MyCommand = new OleDbCommand(insertString, MyConnection);
            MyConnection.Open();
            
                MyCommand.ExecuteNonQuery();
                
            
           
                MyConnection.Close();
               
                dvProposal_DataRebind();
            
    
        }
    
    
    
        protected void dvProposal_OnItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            string deleteString = "delete from Proposal where ProposalNo=" + e.Values[0];
    
            OleDbConnection MyConnection = new OleDbConnection(connectionString);
            OleDbCommand MyCommand = new OleDbCommand(deleteString, MyConnection);
            MyConnection.Open();
    
            MyCommand.ExecuteNonQuery();
    
            MyConnection.Close();
    
    
            dvProposal_DataRebind();
        }
    
    }
