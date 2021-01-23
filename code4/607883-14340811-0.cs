    <asp:UpdatePanel
         ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
                    <asp:Label ID="lblMessage1" runat="server" />
                    <asp:Button ID="btnTrigger1" runat="server"        onclick="Button1_Click" style="visibility:hidden"/>
                  </ContentTemplate>
     </asp:UpdatePanel>
    
    <asp:UpdatePanel
         ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
                     <asp:Label ID="lblMessage2" runat="server" />
                     <asp:Button ID="btnTrigger2" runat="server"        onclick="Button2_Click" style="visibility:hidden"/>
               </ContentTemplate>
     </asp:UpdatePanel>
    
    <script>
         window.onload = function(){
              document.getElementById("<%= btnTrigger1.ClientID %>").click();
              // wait 5 secs to trigger 2nd button
              setTimeout(function(){
                    document.getElementById("<%= btnTrigger2.ClientID %>").click();
              }, 5000);
         };
    </script>
