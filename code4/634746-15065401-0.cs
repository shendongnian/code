    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string month = txtMonth.Text;// should be in the format of Jan, Feb, Mar, Apr, etc...
        int yearofMonth = Convert.ToInt32(txtYear.Text);
        DateTime dateTime = Convert.ToDateTime("01-" + month + "-" + yearofMonth);
        DataRow dr;
        DataTable dt = new DataTable();
        dt.Columns.Add("Monday");
        dt.Columns.Add("Tuesday");
        dt.Columns.Add("Wednesday");
        dt.Columns.Add("Thursday");
        dt.Columns.Add("Friday");
        dr = dt.NewRow();
        for (int i = 0; i < DateTime.DaysInMonth(dateTime.Year, dateTime.Month); i += 1)
        {
            txtMonth.Text = Convert.ToDateTime(dateTime.AddDays(0)).ToString("dddd");
            if (Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd") == "Monday")
            {
                dr["Monday"] = i + 1;
            }
            if (dateTime.AddDays(i).ToString("dddd") == "Tuesday")
            {
                dr["Tuesday"] = i + 1;
            }
            if (dateTime.AddDays(i).ToString("dddd") == "Wednesday")
            {
                dr["Wednesday"] = i + 1;
            }
            if (dateTime.AddDays(i).ToString("dddd") == "Thursday")
            {
                dr["Thursday"] = i + 1;
            }
            if (dateTime.AddDays(i).ToString("dddd") == "Friday")
            {
                dr["Friday"] = i + 1;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                continue;
            }
            if (i == DateTime.DaysInMonth(dateTime.Year, dateTime.Month) - 1)
            {
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
             
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
