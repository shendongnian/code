    namespace SO15888490
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
    
            protected void btnSave_Click(object sender, EventArgs e)
            {
                Session["PhoneNumber"] = txtPhoneNumber.Text;
    
                ArrayList al = new ArrayList();
    
                for (int i = 0; i < ItemListBox.Items.Count; i++)
                {
                    if (ItemListBox.Items[i].Selected == true)
                    {
                        al.Add(ItemListBox.Items[i].Value);
                    }
                }
    
                Session["ItemsList"] = al;
            }
    
        }
