    <script type="text/javascript">
        function getEndDate2(noOfWeeks, sEmployeeWeeklyOfDay, DateStart) {
                // My script code
        //then here an ajax call to the insertDB function
    
      }
    
    <asp:TextBox ID="txtString" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
     <asp:Button ID="btnClick" runat="server" Text="Pass" OnClick="btnClick_Click" />
    
    protected void btnClick_Click(object sender, EventArgs e)
    {
        int noOfweeks = Convert.ToInt16(txtString.Text);;
        string sEmployeeWeeklyOfDay = "Friday";
        string DateStart = DateTime.Now.AddDays(3).ToString();
        btnClick.Attributes.Add("onClick", "getEndDate2('" + noOfweeks + "','" + sEmployeeWeeklyOfDay + "','" + DateStart + "');");
         REMOVE THE+IS CODE TO next function // Some code to insert the values to database
     }
    
    protected void insertDB() // this should be accessible to ajax call
    {
          insert to db function
    
    }
