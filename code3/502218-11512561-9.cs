    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {            
            List<Component> results = new List<Component>();
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                var cn = new OdbcConnection(@"Driver={Microsoft Access Driver (*.mdb)};Dbq=C:\elements.mdb;Uid=Admin;Pwd=;");
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT [PKID], [Col1], [Col2], [Col3], [Cost] ");
                sb.Append("FROM components ");
                sb.Append("WHERE ? IN (Col1, Col2, Col3) ");
                var cm = new OdbcCommand(sb.ToString(), cn);
                try
                {
                    cn.Open();
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.Parameters.AddWithValue("?", itemChecked.ToString());
                    OdbcDataReader dr = cm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var comp = new Component(Convert.ToInt32(dr[0].ToString()),
                                dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToInt32(dr[4].ToString()));
                            Component r = results.Find(
                                delegate(Component c)
                                {
                                    return c.CompoundID == Convert.ToInt32(dr[0].ToString());
                                }
                                );
                            if (r != null)
                            {
                                //update the frequency
                                var obj = results.FirstOrDefault(x => x.CompoundID == comp.CompoundID);
                                if (obj != null) obj.Frequency++;
                            }
                            else { results.Add(comp); }
                        }
                    }
                    dr.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { cn.Close(); }
            }
            //process/present results at this point
            //for each result in list with freq >= 3, output to grid
            IEnumerable<Component> rowsWithThreeHits = results.Where(cFreq => int.Equals(cFreq.Frequency, 3))
                .Select(x => new Component { CompoundID = x.CompoundID, Component1 = x.Component1, 
                    Component2 = x.Component2, Component3 = x.Component3, CompoundValue = x.CompoundValue });
            List<Component> final = new List<Component>(rowsWithThreeHits);
            dataGridView1.DataSource = final;
        }        
    }
    public class Component
    {
        public int CompoundID { get; set; }
        public string Component1 { get; set; }
        public string Component2 { get; set; }
        public string Component3 { get; set; }
        public int CompoundValue { get; set; }
        public int Frequency { get; set; }
        public Component() {}
        public Component(int compoundID, string component1, string component2, string component3, int compoundValue)
        {
            CompoundID = compoundID; 
            Component1 = component1;
            Component2 = component2;
            Component3 = component3;
            CompoundValue = compoundValue;
            Frequency = 1;
        }
    }
