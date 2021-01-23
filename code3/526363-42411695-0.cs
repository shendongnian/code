        string[] Month = new string[]{"Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
        HtmlTableRow tr;
        HtmlTableCell tc;
        Button btn;
        Label lbl;
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (Control control in ph1.Controls)
            {
                ph1.Controls.Remove(control);
            }
            if (!Page.IsPostBack)
            {
                Session["Calander"] = null;
                var dt = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 01);
                var dttable = new DataTable();
                dttable.Columns.Add("type", typeof (string));
                dttable.Columns.Add("value", typeof (DateTime));
                var dr = dttable.NewRow();
                dr["type"] = "M-Y";
                dr["value"] = dt;
                dttable.Rows.Add(dr);
                GenerateTable(dttable);
                for (int i = 1; i < 32; i++)
                {
                    ddlday.Items.Add(new ListItem(i.ToString(CultureInfo.InvariantCulture),i.ToString(CultureInfo.InvariantCulture)));
                }
                ddlmonth.DataSource = Month;
                ddlmonth.DataBind();
            }
            for (int i = 1900; i < DateTime.Now.Year; i++)
            {
                ddlyear.Items.Add(new ListItem(i.ToString(CultureInfo.InvariantCulture), i.ToString(CultureInfo.InvariantCulture)));
            }
            if (Session["Calander"] != null)
            {
                var dtSession = (DataTable) Session["Calander"];
                GenerateTable(dtSession);
            }
        }
        private void GenerateTable(DataTable dtSession)
        {
            foreach (Control c in ph1.Controls)
            {
                ph1.Controls.Remove(c);
            }
            var datesession = new DateTime();
            if (dtSession.Rows.Count > 0)
            {
                datesession = Convert.ToDateTime(dtSession.Rows[0]["value"]);
            }
            var count = 0;
            var tb1 = new HtmlTable();
            tb1.Style.Add(HtmlTextWriterStyle.BorderWidth,"1px");
            tb1.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
            tb1.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
            tr = new HtmlTableRow();
            tb1.Rows.Add(tr);
            tc = new HtmlTableCell();
            tc.Style.Add(HtmlTextWriterStyle.BorderWidth,"1px");
            tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
            tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
            tc.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            tr.Cells.Add(tc);
            btn = new Button();
            btn.Style.Add(HtmlTextWriterStyle.TextAlign,"left");
            btn.ID = "btnmonpre";
            btn.Text = "<<";
            btn.Click += new EventHandler(btnmonpre_Click); 
            tc.Controls.Add(btn);
            tc = new HtmlTableCell();
            tc.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
            tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
            tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
            tc.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
            if (dtSession.Rows[0]["type"].ToString() == "M-Y")
            {
                tc.ColSpan = 5;
            }
            tr.Cells.Add(tc);
            btn = new Button();
            btn.ID = "btnmonyear";
            if (Convert.ToString(dtSession.Rows[0]["type"]) == "M-Y")
            {
                btn.Text = Month[datesession.Month - 1] + "-" + datesession.Year.ToString(CultureInfo.InvariantCulture);
            }
            tc.Controls.Add(btn);
            btn.Click += new EventHandler(BtnMonYear_clicl);
            tc = new HtmlTableCell();
            tc.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
            tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
            tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
            tc.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            tr.Cells.Add(tc);
            btn = new Button();
            btn.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            btn.ID = "btnmonnext";
            btn.Text = ">>";
            btn.Click += new EventHandler(btnmonnext_Click);
            tc.Controls.Add(btn);
            if (dtSession.Rows[0]["type"].ToString() == "M-Y")
            {
                int startPoint = 0, endPoint = 0, DatePlaceCount = 0;
                var firstDate = new DateTime(datesession.Year,datesession.Month,01);
                startPoint = (int) firstDate.DayOfWeek;
                if (startPoint == 0)
                {
                    startPoint = 7;
                }
                endPoint = firstDate.AddMonths(1).AddDays(-1).Day;
                int previousDays = firstDate.AddDays(-1).Day;
                int pDatePlace = previousDays - (startPoint - 2);
                int nDatePlace = 1; 
                tr = new HtmlTableRow();
                tb1.Rows.Add(tr);
                tc = new HtmlTableCell();
                tc.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
                tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
                tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
                tc.Style.Add(HtmlTextWriterStyle.Width, "60px");
                tc.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
                tr.Cells.Add(tc);
                lbl = new Label();
                lbl.ID = "day1";
                lbl.Text = "Mon";
                tc.Controls.Add(lbl);
                tc = new HtmlTableCell();
                tc.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
                tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
                tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
                tc.Style.Add(HtmlTextWriterStyle.Width, "60px");
                tc.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
                tr.Cells.Add(tc);
                lbl = new Label();
                lbl.ID = "day2";
                lbl.Text = "Tue";
                tc.Controls.Add(lbl);
                tc = new HtmlTableCell();
                tc.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
                tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
                tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
                tc.Style.Add(HtmlTextWriterStyle.Width, "60px");
                tc.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
                tr.Cells.Add(tc);
                lbl = new Label();
                lbl.ID = "day3";
                lbl.Text = "Wed";
                tc.Controls.Add(lbl);
                tc = new HtmlTableCell();
                tc.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");  
                tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
                tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
                tc.Style.Add(HtmlTextWriterStyle.Width, "60px");
                tc.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
                tr.Cells.Add(tc);
                lbl = new Label();
                lbl.ID = "day4";
                lbl.Text = "Thu";
                tc.Controls.Add(lbl);
                tc = new HtmlTableCell();
                tc.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px"); 
                tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
                tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
                tc.Style.Add(HtmlTextWriterStyle.Width, "60px");
                tc.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
                tr.Cells.Add(tc);
                lbl = new Label();
                lbl.ID = "day5";
                lbl.Text = "Fri";
                tc.Controls.Add(lbl);
                tc = new HtmlTableCell();
                tc.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
                tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
                tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
                tc.Style.Add(HtmlTextWriterStyle.Width, "60px");
                tc.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
                tr.Cells.Add(tc);
                lbl = new Label();
                lbl.ID = "day6";
                lbl.Text = "Sat";
                tc.Controls.Add(lbl);
                tc = new HtmlTableCell();
                tc.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
                tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
                tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
                tc.Style.Add(HtmlTextWriterStyle.Width, "60px");
                tc.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
                tr.Cells.Add(tc);
                lbl = new Label();
                lbl.ID = "day7";
                lbl.Text = "Sun";
                tc.Controls.Add(lbl);
                tb1.Rows.Add(tr);
                for (int i = 0; i < 6; i++)
                {
                    tr = new HtmlTableRow();
                    tb1.Rows.Add(tr);
                    for (int j = 1; j < 8; j++)
                    {
                        tc = new HtmlTableCell();
                        tc.Style.Add(HtmlTextWriterStyle.BorderWidth,"1px");
                        tc.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
                        tc.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
                        tc.Style.Add(HtmlTextWriterStyle.Width, "60px");
                        tc.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
                        tr.Cells.Add(tc);
                        count++;
                        if (count >= startPoint && count < startPoint + endPoint) // current month dateplace
                        {
                            DatePlaceCount++;
                            btn = new Button();
                            btn.Text = DatePlaceCount.ToString();
                            btn.ID = btn + count.ToString();
                            btn.EnableViewState = false;
                            btn.Click += new EventHandler(btnClick);
                            tc.Controls.Add(btn);
                        }
                        else
                        {
                            if (count < startPoint) // Previous month
                            {
                                btn = new Button();
                                btn.Text = pDatePlace.ToString();
                                btn.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                                btn.ID = btn + count.ToString();
                                btn.ValidationGroup = "Prev";
                                btn.EnableViewState = false;
                                btn.Click += new EventHandler(btnClick);
                                tc.Controls.Add(btn);
                                pDatePlace++;
                            }
                            else if (count >= startPoint + endPoint) // Next month
                            {
                                btn = new Button();
                                btn.Text = nDatePlace.ToString();
                                btn.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Blue");
                                btn.ID = btn + count.ToString();
                                btn.ValidationGroup = "Next";
                                btn.EnableViewState = false;
                                btn.Click += new EventHandler(btnClick);
                                tc.Controls.Add(btn);
                                nDatePlace++;
                            }
                        }
                    }
                }
                ph1.Controls.Add(tb1);
                Session["Calander"] = null;
                dtSession.Rows.Clear();
                DataRow dr = dtSession.NewRow();
                dr["type"] = "M-Y";
                dr["value"] = new DateTime(firstDate.Year, firstDate.Month, firstDate.Day);
                dtSession.Rows.Add(dr);
                Session["Calander"] = dtSession;
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            var dt = new DateTime();
            //var dt1 = DateTime.TryParse(ddlyear.SelectedValue.ToString(CultureInfo.InvariantCulture) + "/" + Array.IndexOf(Month, ddlmonth.SelectedValue.ToString(CultureInfo.InvariantCulture)) + 1.ToString(CultureInfo.InvariantCulture) + "/" + ddlday.SelectedValue.ToString(CultureInfo.InvariantCulture), out dt);
            var year = ddlyear.SelectedValue.ToString(CultureInfo.InvariantCulture);
            var month = Convert.ToInt32(Array.IndexOf(Month, ddlmonth.SelectedValue.ToString(CultureInfo.InvariantCulture))) + 1;
            var date = ddlday.SelectedValue.ToString(CultureInfo.InvariantCulture);
            var dt1 = DateTime.Parse(month + "/" + date + "/" + year);
            if (dt1 != DateTime.MinValue)
            {
                if (Session["Calander"] != null)
                {
                    Session["Calander"] = null;
                    // DateTime dt1 = new DateTime(Convert.ToInt32(ddlyear.SelectedValue.ToString(CultureInfo.InvariantCulture)), Convert.ToInt32(ddlmonth.SelectedValue.ToString(CultureInfo.InvariantCulture)), Convert.ToInt32(ddlday.SelectedValue.ToString(CultureInfo.InvariantCulture)));
                    DataTable dtTable = new DataTable();
                    dtTable.Columns.Add("type", typeof(string));
                    dtTable.Columns.Add("value", typeof(DateTime));
                    DataRow dr = dtTable.NewRow();
                    dr["type"] = "M-Y";
                    dr["value"] = dt1;
                    dtTable.Rows.Add(dr);
                    GenerateTable(dtTable);
                    Response.Write(" U R Selecting Date:" + dt1.ToString("dd/MMM/yyyy"));
                    // var dtSession = (DataTable)Session["Calander"];
                    // GenerateTable(dtSession);
                   
                }
            }
        }
        protected void btnmonpre_Click(object sender, EventArgs e)
        {
            DataTable dtsession = (DataTable)Session["Calander"];
            DateTime datesession = Convert.ToDateTime(dtsession.Rows[0]["value"]);
            if (Convert.ToString(dtsession.Rows[0]["type"]) == "M-Y")
            {
                if (datesession.AddMonths(-1).Year >= 1970)
                {
                    dtsession.Rows[0]["value"] = datesession.AddMonths(-1);
                }
                Session["Calander"] = dtsession;
                GenerateTable(dtsession);
            }
        }
        protected void btnmonnext_Click(object sender, EventArgs e) 
        {
            DataTable dtsession = (DataTable)Session["Calander"];
            DateTime datesession = Convert.ToDateTime(dtsession.Rows[0]["value"]);
            if (Convert.ToString(dtsession.Rows[0]["type"]) == "M-Y")
            {
                if (datesession.AddMonths(1).Year <= 2070)
                {
                    dtsession.Rows[0]["value"] = datesession.AddMonths(1);
                }
                Session["Calander"] = dtsession;
                GenerateTable(dtsession);
            }
        }
        protected void BtnMonYear_clicl(object sender, EventArgs e)
        {
            DataTable dtSession = (DataTable)Session["Calander"];
            DateTime datesession = (DateTime)dtSession.Rows[0]["value"];
            if (dtSession.Rows[0]["type"].ToString() == "M-Y")
            {
                dtSession.Clear();
                DataRow dr = dtSession.NewRow();
                dr["type"] = "M-Y";
                dr["value"] = datesession;
                dtSession.Rows.Add(dr);
                Session["Calander"] = dtSession;
                GenerateTable(dtSession);
            }
        }
        protected void btnClick(object sender, EventArgs e) 
        {
            DataTable dtsession = (DataTable)Session["Calander"];
            Button b = (Button)sender;
            DateTime ResultDate;
            DateTime dt;
            if (Convert.ToString(dtsession.Rows[0]["type"]) == "M-Y")
            {
                if (b.ValidationGroup == "Prev")
                {
                    dt = (DateTime)(dtsession.Rows[0]["value"]);
                    dt = dt.AddMonths(-1);
                    ResultDate = new DateTime(dt.Year, dt.Month, Convert.ToInt32(b.Text));
                    b.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                    Response.Write("U R Selecting Date:" + ResultDate.ToString("dd/MMM/yyyy"));
                }
                else if (b.ValidationGroup == "Next")
                {
                    dt = (DateTime)(dtsession.Rows[0]["value"]);
                    dt = dt.AddMonths(1);
                    ResultDate = new DateTime(dt.Year, dt.Month, Convert.ToInt32(b.Text));
                    b.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                    Response.Write(" U R Selecting Date:" + ResultDate.ToString("dd/MMM/yyyy"));
                }
                else
                {
                    dt = (DateTime)(dtsession.Rows[0]["value"]);
                    ResultDate = new DateTime(dt.Year, dt.Month, Convert.ToInt32(b.Text));
                    b.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                    Response.Write(" U R Selecting Date:" + ResultDate.ToString("dd/MMM/yyyy"));
                }
            }
        }
    }
  
