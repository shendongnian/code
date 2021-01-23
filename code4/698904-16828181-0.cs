    if (!IsPostBack)
    {
     if (Session["Enq_ID"] != null)
     {
     string EnquiryID = Session["Enq_ID"].ToString();
     int Enquiry =Int32.Parse(EnquiryID);
     hotelOBJ.FillbyQueryEnquiry1(Enquiry, txtClientph, txtClientAddress );
     }
    }
