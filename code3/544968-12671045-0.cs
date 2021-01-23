    <ListView.View>
                <GridView AllowsColumnReorder="False" x:Name="GridView1">
                    <GridViewColumn Header="Customer Name" DisplayMemberBinding="{Binding Path=Customer}" ></GridViewColumn>
                    <GridViewColumn Header="Order ID" DisplayMemberBinding="{Binding Path=OrderID}" ></GridViewColumn>
                    <GridViewColumn Header="Invoice ID">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <TextBox x:Name="InvoiceID" HorizontalAlignment="Stretch" Width="100" Text="{Binding ElementName=GroupInvoiceID, Path=Text, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" BorderThickness="1" BorderBrush="#FFA4C5E8" 
                                         cal:Message.Attach="[Event TextChanged]=[Action InvoiceID_TextChanged($datacontext, $eventArgs)]" />
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
