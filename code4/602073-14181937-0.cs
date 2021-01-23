    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Windows.Forms;
    using System;
    public partial class MakeAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string appointmentdate = Convert.ToString(DropDownListDay.Text + "-" + DropDownListMonth.Text + "-" + DropDownListYear.Text);
            string appointmenttime = Convert.ToString(DropDownListHour.Text + ":" + DropDownListMinute.Text + ":" + DropDownListSecond.Text + " " + DropDownListSession.Text);
    
            using (SqlConnection con = new SqlConnection("Data Source=USER-PC;Initial Catalog=webservice_database;Integrated Security=True"))
            {
                con.Open();
                SqlCommand date = new SqlCommand("Select adate from customer_registration where adate='" + appointmentdate + "'", con);
                string ddate = date.ExecuteScalar().ToString();
                if (ddate == appointmentdate)
                {
                    SqlCommand time = new SqlCommand("Select atime from customer_registration where atime='" + appointmenttime + "'", con);
                    if (time.ExecuteScalar() != null)
                    {
                        string dtime = time.ExecuteScalar().ToString();
    
                        if (dtime == appointmenttime)
                        {
                            MessageBox.Show("This appointment is not available. Please choose other date & time.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to fetch time from database");
                    }
                }
                con.Close();
            }
        }
    }
