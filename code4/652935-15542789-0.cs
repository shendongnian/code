    <script runat="server">
        void innerRpItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                var lit = (Literal) ((Control) sender).Parent.FindControl("count");
                lit.Text = string.IsNullOrWhiteSpace(lit.Text) ? "1" : (int.Parse(lit.Text) + 1).ToString();
            }
        } 
    </script>
    
    <asp:Repeater ID="rptOuterRepeater" runat="server" >
       <ItemTemplate>
                <tr >
                  <td>
                  // Need some code logic here for counting
                  <asp:Literal runat="server" ID="count"/>
                  </td>
               </tr>
                <tr>
                <td>
                     <asp:Repeater ID="rptInnerRepeater" runat="server" OnItemDataBound="innerRpItemDataBound" >
                    <ItemTemplate>
                         <tr >
                            <td>
                              &nbsp;
                           </td>
                         </tr>
                      </ItemTemplate>
                 </td>
                </tr>
         </ItemTemplate>
       </asp:Repeater>
