    Put this in the body of Default page
    
    <body>
        <form id="form1" runat="server">
            <table title="mxit:table:full" style="width: 100%;" align="center">
                <tr style="background-color: red; text-align: center;">
                    <td style="width: 25%;">
                        <a href="Default.aspx?id=prev">&lt; Prev</a>
                    </td>
                    <td style="width: 50%;">
                        <asp:Label ID="lblMonth" runat="server"></asp:Label>&nbsp;&nbsp;
                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                        <br />
                    </td>
                    <td style="width: 25%">
                        <a href="Default.aspx?id=next">Next &gt;</a>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lbltest" runat="server" Text=""></asp:Label>
        </form>
    </body>
    
    Put this in the code Behind Default.aspx.cs
    
        using System;
        using System.Collections.Generic;
        using System.Globalization;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    try
                    {
                        if (Request.QueryString["id"] == "next")
                        {
                            if ((int)Session["currentMonth"] >= 12)
                            {
                                Session["currentMonth"] = 1;
                                Session["currentYear"] = (int)Session["currentYear"] + 1;
                            }
                            else
                            {
                                Session["currentMonth"] = (int)Session["currentMonth"] + 1;
                            }
                            DateTime dt = new DateTime((int)Session["currentYear"], (int)(Session["currentMonth"]), 1);
                            string obj = dt.DayOfWeek.ToString();
                            GetCalender(obj);
                        }
                        else if (Request.QueryString["id"] == "prev")
                        {
                            if ((int)Session["currentMonth"] <= 1)
                            {
                                Session["currentMonth"] = 12;
                                Session["currentYear"] = (int)Session["currentYear"] - 1;
                            }
                            else
                            {
                                Session["currentMonth"] = (int)Session["currentMonth"] - 1;
                            }
                            DateTime dt = new DateTime((int)Session["currentYear"], (int)(Session["currentMonth"]), 1);
                            string obj = dt.DayOfWeek.ToString();
                            GetCalender(obj);
                        }
                        else //this will run when we start the project
                        {
                            int currentYear = DateTime.Now.Year;
                            int currentMonth = DateTime.Now.Month;
                            Session["currentMonth"] = currentMonth;
                            Session["currentYear"] = currentYear;
                            DateTime dt = new DateTime((int)Session["currentYear"], (int)(Session["currentMonth"]), 1);
                            string obj = dt.DayOfWeek.ToString();
                            GetCalender(obj);
                        }
                    }
                    catch
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            private void GetCalender(string obj)
            {
                try
                {
                    string[] months = new string[] {"January", "February", "March", "April", "May",
          "June", "July", "August", "September", "October", "November", "December"};
                    DayOfWeek objDayofweek = DateTime.Today.Date.DayOfWeek;
                    lbltest.Text = "<table style='width:100%' align='center'><colgroup span='7' style='width:15%'></colgroup><tr><td>Mon</td>";
                    lbltest.Text = lbltest.Text + "<td>Tue</td>";
                    lbltest.Text = lbltest.Text + "<td>Wed</td>";
                    lbltest.Text = lbltest.Text + "<td>Thu</td>";
                    lbltest.Text = lbltest.Text + "<td>Fri</td>";
                    lbltest.Text = lbltest.Text + "<td>Sat</td>";
                    lbltest.Text = lbltest.Text + "<td>Sun</td></tr><tr>";
                    int y = 1;
                    switch (obj.ToString())
                    {
                        case "Monday":
                            y = 1;
                            break;
                        case "Tuesday":
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            y = 2;
                            break;
                        case "Wednesday":
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            y = 3;
                            break;
                        case "Thursday":
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            y = 4;
                            break;
                        case "Friday":
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            y = 5;
                            break;
                        case "Saturday":
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            y = 6;
                            break;
                        case "Sunday":
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            lbltest.Text = lbltest.Text + "<td>&nbsp</td>";
                            y = 7;
                            break;
                    }
                    for (int dayday = Convert.ToInt32(objDayofweek); dayday <= DateTime.DaysInMonth((int)Session["currentYear"], (int)(Session["currentMonth"])); dayday++)
                    {
                        if (y < 7)
                        {
                            lbltest.Text = lbltest.Text + "<td><a href='#Date=" + dayday.ToString() + "/" + Session["currentMonth"] + "/" + Session["currentYear"] + "'>" + dayday.ToString() + "</a></td>";
                            y++;
                        }
                        else
                        {
                            lbltest.Text = lbltest.Text + "<td><a href='#Date=" + dayday.ToString() + "/" + Session["currentMonth"] + "/" + Session["currentYear"] + "'>" + dayday.ToString() + "</a></td>";
                            y = 1;
                            lbltest.Text = lbltest.Text + "</tr><tr>";
                        }
                    }
                    lbltest.Text = lbltest.Text + "</tr></table>";
                    lblMonth.Text = months[(int)Session["currentMonth"] - 1].ToString();
                    lblYear.Text = Session["currentYear"].ToString();
                }
                catch
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
