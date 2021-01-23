    <MasterTableView CommandItemDisplay="Top" EditMode="InPlace">
                <Columns>
                    <telerik:GridBoundColumn DataField="ID" UniqueName="ID" HeaderText="ID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" UniqueName="Name" HeaderText="Name">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:Image ID="imgStatus" runat="server" ImageUrl="http://promote.opera.com/logos/Opera-icon-high-res.png"
                                Height="20px" Width="20px" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Booked Off">
                        <ItemTemplate>
                            <telerik:RadNumericTextBox ID="nmBookedOff" runat="server" MinValue="0" ShowSpinButtons="true"
                                Type="Number" NumberFormat-DecimalDigits="0" ClientEvents-OnValueChanged='valueChanged'>
                            </telerik:RadNumericTextBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridEditCommandColumn>
                    </telerik:GridEditCommandColumn>
                </Columns>
            </MasterTableView>
