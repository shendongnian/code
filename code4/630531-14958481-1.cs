    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            onrowdatabound="GridView1_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="RollNo" HeaderText="RollNo" />
                                <asp:TemplateField HeaderText="Date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                            TargetControlID="TextBox1">
                                        </asp:CalendarExtender>
                                    </EditItemTemplate>
                                    <HeaderTemplate>                                   
                                        &nbsp;
               </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender2"
                                            runat="server" TargetControlID="TextBox2">
                                        </asp:CalendarExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Time" />
                                <asp:TemplateField HeaderText="Present">
                                    <AlternatingItemTemplate>
                                        <asp:CheckBox ID="cbSelectAll1" runat="server" onclick="CheckBoxCheck(this)" />
                                    </AlternatingItemTemplate>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAll1" runat="server" Text="All Absent" 
                                            onclick="CheckBoxCheck(this)" AutoPostBack="True" ValidationGroup="a" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbSelectAll1" runat="server" onclick="CheckBoxCheck(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                        <asp:TemplateField>
                        <AlternatingItemTemplate>
                            <asp:CheckBox ID="cbSelectAll" runat="server" onclick="CheckBoxCheck(this)"/>
                        </AlternatingItemTemplate>
                        <HeaderTemplate>
                            <asp:CheckBox ID="cbSelectAll" runat="server" Text="All Present" 
                                onclick="CheckBoxCheck(this)" AutoPostBack="True" ValidationGroup="a" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbSelectAll" runat="server" onclick="CheckBoxCheck(this)" />
                        </ItemTemplate>
                    </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
