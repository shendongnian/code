    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    
    public partial class BirthDateWebUserControl : System.Web.UI.UserControl
    {
        private readonly string ViewStateKey = "BirthDateWebUserControl_VSKEY";
        public DateTime BirthDate
        {
            get
            {
                int day = int.Parse(((DropDownList)this.FindControl("DayDropDown")).SelectedValue);
                int month = int.Parse(((DropDownList)this.FindControl("MonthDropDown")).SelectedValue);
                int year = int.Parse(((DropDownList)this.FindControl("YearDropDown")).SelectedValue);
                return new DateTime(year, month, day);
            }
            set
            {
                ((DropDownList)this.FindControl("DayDropDown")).SelectedValue = value.Day.ToString("00");
                ((DropDownList)this.FindControl("MonthDropDown")).SelectedValue = value.Month.ToString("00");
                ((DropDownList)this.FindControl("YearDropDown")).SelectedValue = value.Year.ToString("00");
            }
        }
    
        protected void Page_Init(object sender, EventArgs e)
        {
            DropDownList dd = new DropDownList();
            dd.ID = "DayDropDown";
            DropDownList dm = new DropDownList();
            dm.ID = "MonthDropDown";
            DropDownList dy = new DropDownList();
            dy.ID = "YearDropDown";
    
            this.Controls.Add(dd);
            this.Controls.Add(dm);
            this.Controls.Add(dy);
    
            if (ViewState[ViewStateKey] == null)
            {
    
                dd.Items.Add(new ListItem("day", "0"));
                dm.Items.Add(new ListItem("month", "0"));
                dy.Items.Add(new ListItem("year", "0"));
    
                dd.Items.AddRange(GetNumericValues(1, 31).ToArray());
                dm.Items.AddRange(GetNumericValues(1, 12).ToArray());
                int yearNow = DateTime.Now.Year;
                dy.Items.AddRange(GetNumericValues(yearNow - 100, yearNow - 17).ToArray());
    
                dd.DataBind();
                dm.DataBind();
                dy.DataBind();
    
                ViewState[ViewStateKey] = true;
            }
        }
    
        private List<ListItem> GetNumericValues(int from, int to)
        {
            List<ListItem> n = new List<ListItem>();
            for (int i = from; i <= to; i++)
            {
                n.Add(new ListItem(i < 10 ? "0" + i.ToString() : i.ToString()));
            }
            return n;
        }
    }
