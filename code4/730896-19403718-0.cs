    <asp:GridView runat="server" AutoGenerateColumns="false" ID="grdCustomers" DataKeyNames="CustomerID" AllowSorting="true"
                         OnRowEditing="grdCustomers_RowEditing" OnRowDeleting="grdCustomers_RowDeleting" HeaderStyle-BackColor = "green"
                         OnRowUpdating="grdCustomers_RowUpdating" OnRowCancelingEdit="grdCustomers_RowCancelingEdit"  AllowPaging="false"  ShowFooter="true" >
                        <Columns>
                            <asp:TemplateField HeaderText="Customer Id">
                                <ItemTemplate>
                                    <asp:Label Text='<%#Eval("CustomerID")%>' HeaderText=""  runat="server" ID="lblcustomerId"   />
                                </ItemTemplate>
                              
                            </asp:TemplateField>
                          
                                 <asp:TemplateField HeaderText="Contact Name">
                                <ItemTemplate>
                                     <asp:Label Text='<%#Eval("ContactName")%>' ID="lblCustomerName" runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtContactName" runat="server" />
                                </EditItemTemplate>
                                        
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                   
                                    <asp:Label id="lblCity" Text='<%#Eval("City")%>' runat="server" /> 
                                </ItemTemplate>
                                <EditItemTemplate>
                                  <asp:DropDownList ID="ddlCity1" runat="server" DataTextField="City" DataValueField="City"></asp:DropDownList>
                                </EditItemTemplate>
                             
                            </asp:TemplateField>
                           <asp:CommandField ShowEditButton="true" HeaderText="Edit"  />
                  
                          
                        </Columns>
                        
                    </asp:GridView>
