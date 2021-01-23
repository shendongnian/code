    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    List<Abc> listofAbc = new List<Abc>();
                    for (int i = 0; i < 10; i++)
                    {
                        listofAbc.Add(new Abc
                        {
                            ID = i + 1,
                            Name = "Abc" + (i + 1).ToString()
                        });
                    }
                    GridView1.DataSource = listofAbc;
                    GridView1.DataBind();
    
                    List<string> lst = new List<string>();
    
                    for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
                    {
    
                        lst.Add(GridView1.HeaderRow.Cells[i].Text);
                        System.Diagnostics.Debug.WriteLine(GridView1.HeaderRow.Cells[i].Text);
                    }
                }
            }
        }
        public class Abc
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
