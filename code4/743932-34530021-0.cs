**
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Data.SqlClient;
    public partial class _Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=mrinmoynandy;User ID=**;Password=****");
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void SumbitBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into streg(Name,Father,Mother,Dob,Sex,Category,Maritial,Vill,Po,Ps,Dist,State,Pin,Country) values (@name,@father,@mother,@dob,@sex,@category,@maritial,@vill,@po,@ps,@dist,@state,@pin,@country)", con);
            cmd.Parameters.AddWithValue(@"name", StNumTxt.Text);
            cmd.Parameters.AddWithValue(@"father", FatNumTxt.Text);
            cmd.Parameters.AddWithValue(@"mother", MotNumTxt.Text);
            cmd.Parameters.AddWithValue(@"dob", DobRdp.SelectedDate);
            cmd.Parameters.AddWithValue(@"sex", SexDdl.SelectedItem.Text);
            cmd.Parameters.AddWithValue(@"category", CategoryDdl.SelectedItem.Text);
            cmd.Parameters.AddWithValue(@"maritial", MaritialRbl.SelectedItem.Text);
            cmd.Parameters.AddWithValue(@"vill", VillTxt.Text);
            cmd.Parameters.AddWithValue(@"po", PoTxt.Text);
            cmd.Parameters.AddWithValue(@"ps", PsTxt.Text);
            cmd.Parameters.AddWithValue(@"dist", DistDdl.SelectedItem.Text);
            cmd.Parameters.AddWithValue(@"state", StateTxt.Text);
            cmd.Parameters.AddWithValue(@"pin", PinTxt.Text);
            cmd.Parameters.AddWithValue(@"country", CountryTxt.Text);
            con.Open();        
            con.Close();        
        }
    }
    Thanks
    Mrinmoy Nandy
    Phone No.: +91 9800451398
**
