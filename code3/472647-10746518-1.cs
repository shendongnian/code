    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class ListBoxEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnCount_Click(object sender, EventArgs e)
        {
            PopulateDestinationListBox();
            int itemCount = ListBox2.Items.Count;
            tbCount.Text = itemCount.ToString();
        }
        protected void lbCount_Click(object sender, EventArgs e)
        {
            int itemCount = ListBox2.Items.Count;
            tbCount.Text = itemCount.ToString();
        }
    
        private void PopulateDestinationListBox()
        {
            ListBox2.Items.Clear();
            string[] pairs = hfLB2Items.Value.Split('|');
            if (pairs.Length == 0 && string.IsNullOrEmpty(pairs[0]))
                return;
            foreach (string pair in pairs)
            {
                string[] values = pair.Split('~');
                ListBox2.Items.Add(new ListItem(values[0], values[1]));
            }
        }
    }
