        private void BindGrid()
          {
            DataTable dt = new DataTable();
            dt.Columns.Add("Test DropDown");
            
            Control container = new Control();
            TemplateField tf = new TemplateField();
            string chkRole = "ddlTest";
            
           
            tf.ItemTemplate = new CreateDropDownList(chkRole);
            //tf.HeaderText = dt.Columns[i].ColumnName;
            this.gvDDL.Columns.Add(tf);
            gvDDL.DataSource = dt;
            gvDDL.DataBind();
        }
        
    }
    public class CreateDropDownList:ITemplate
     {
        string checkboxID;
        public CreateDropDownList(string id)
        {
            this.checkboxID = id;
            //
            // TODO: Add constructor logic here
            //
        }
        public void InstantiateIn(Control container)
        {
            DropDownList ddl = new DropDownList();
            ddl.ID = checkboxID;
            container.Controls.Add(ddl);
        }
     }
