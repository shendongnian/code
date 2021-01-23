    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class DemoPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                
                string strSql = @"Insert Into SampleTable (Check1, Check2, Check3, Text, ListBoxResult) 
                                                   Values (@Value1, @Value2, @Value3, @TextValue, @ListResult)";
                SqlCommand cmd = new SqlCommand(strSql);
                
                // Handle CheckBoxList values
                int checkValue=0;
                foreach (ListItem sampleItem in SampleCheckBox.Items)
                {
                    checkValue++; //increment ID used to build parameter name
                    string parmName=String.Format("@Value{0}",checkValue);
                    SqlParameter newParameter = new SqlParameter();
                    newParameter.ParameterName = parmName;
                    if (sampleItem.Selected)
                    {
                        newParameter.Value = "Y";
                        //column value in DB for field corresponding to sampleItem is "Y"
                    }
                    else
                    {
                        newParameter.Value="N";
                        //column value in DB for field corresponding to sampleItem is "n"
                    }
                    cmd.Parameters.Add(newParameter);
                }
    
                // Handle TextBox value
                cmd.Parameters.Add("@TextValue", SampleTextBox.Text);
    
                // Handle ListBox selected value
                cmd.Parameters.Add("@ListResult", SampleListBox.SelectedValue);
    
                cmd.ExecuteNonQuery();
            }
        }
    }
