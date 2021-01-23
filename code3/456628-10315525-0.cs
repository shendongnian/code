        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pID = Convert.ToInt32(Request["pid"]);
                if(pID != 0)
                {
                    FillPatientInfo(pID);
                    hidField.Value = pID;
                }
            }
            else
            {
                pID = Convert.ToInt32(hidField.Value);
            }
        }
