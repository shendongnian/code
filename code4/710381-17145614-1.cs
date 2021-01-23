        protected void btnAdd_Click(object sender, EventArgs e)
        {
            List<temp> lst = GetItemFromRpt();
            lst.Add(new temp
            {
                str1=TextBox1.Text,
                str2 = TextBox2.Text
            });
            rpt.DataSource = lst;
            rpt.DataBind();
        }
        private List<temp> GetItemFromRpt()
        {
            List<temp> lst = new List<temp>();
            for (int i = 0; i < rpt.Items.Count; i++)
            {
                temp obj = new temp();
                obj.str1 = ((TextBox)rpt.Items[i].FindControl("txt1")).Text;
                obj.str2 = ((TextBox)rpt.Items[i].FindControl("txt2")).Text;
                lst.Add(obj);
            }
            return lst;
        }
        public class temp // instead of temp you can use whatever your entity class you need
        {
            public string str1 { get; set; }
            public string str2 { get; set; }
        }
