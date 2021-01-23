    <asp:TextBox ID="txt_ReasonCode" 
                 onchange="disableNextStatusButtons()" 
                 runat="server"
                 Text='<%# Bind("ReasonCode") %>'
                 Enabled='<%# (Roles.IsUserInRole("İhracat Uzmanı") && Session["Status"].ToString()=="3") %>'
                 BackColor='<%# (Roles.IsUserInRole("İhracat Uzmanı") && Session["Status"].ToString()=="3") ? System.Drawing.Color.Red: System.Drawing.Color.Green %>'
                 Width="40px">
    </asp:TextBox>
