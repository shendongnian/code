    using (DataTable data = GeneralFunctions.GetData(query))
    {
        if (data != null && data.Rows.Count > 0)
        {
            object sumObject;
            sumObject = data.Compute("Sum(Minutes_Spent)", "");
            if (reportType == 1)
            {
                RepeaterPCBillable.DataSource = data;
                RepeaterPCBillable.DataBind();
                LabelPCBillable.Text = ParseTime(int.Parse(sumObject.ToString())) == null
                    ? ParseTime(int.Parse(sumObject.ToString()))
                    : "";
            }
            else
            {
                RepeaterDTSTBillable.DataSource = data;
                RepeaterDTSTBillable.DataBind();
                LabelDTSTBillable.Text = ParseTime(int.Parse(sumObject.ToString())) == null
                    ? ParseTime(int.Parse(sumObject.ToString()))
                    : "";
            }
        }
    }
