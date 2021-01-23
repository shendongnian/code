    <telerik:RadGrid ID="ViewLogsGrid" ... ... >
        
       <MasterTableView TableLayout="Fixed">
          <Columns>
            <telerik:GridBoundColumn DataField="Comments" HeaderText="Comments" SortExpression="Comments"    UniqueName="Comments">
               
               <HeaderStyle Width="150px" />
            </telerik:GridBoundColumn>
          </Columns>
       </MasterTableView>
    </telerik:RadGrid>
