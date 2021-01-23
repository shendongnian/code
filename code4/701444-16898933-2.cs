       protected void Page_Load(object sender, EventArgs e)
            {
                List<string> names = new List<string>();
                names.Add("Jhonatas");
    
                this.GridView1.DataSource = names;
                this.GridView1.DataBind();
    
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    //add checkbox for every row
                    TableCell cell = new TableCell();
                    CheckBox box = new CheckBox();
                    box.AutoPostBack = true;
                    box.ID = gvr.Cells[0].Text;
    
                    box.CheckedChanged += new EventHandler(box_CheckedChanged);
                    cell.Controls.Add(box);
                    gvr.Cells.Add(cell);
                }
            }
    
            void box_CheckedChanged(object sender, EventArgs e)
            {
                string test = "ok";
            }
