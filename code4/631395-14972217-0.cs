    <yourNameSpace:ScrollingGrid runat="server" ID=sg1 
           Width=450 Height=240 CssClass=sgTbl>
    
        <asp:DataGrid runat="server" ID=Grid2 CellPadding=5 CellSpacing=1
          AutoGenerateColumns=True AllowSorting=True 
          AllowPaging=True PageSize=35>
            <HeaderStyle BackColor=red ForeColor=white Font-Bold=True />
            <ItemStyle BackColor=#fefefe />
            <AlternatingItemStyle BackColor=#eeeeee />
            <PagerStyle BackColor=silver ForeColor=White 
                        Mode=NumericPages />
        </asp:DataGrid>
    
      </yourNameSpace:ScrollingGrid>
