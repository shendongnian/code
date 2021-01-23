      <sdk:DataGrid ItemsSource="{Binding ScheduleInProcessSource.View, Mode= TwoWay}" SelectedItem="{Binding CurrentActivity, Mode=TwoWay}" AutoGenerateColumns="False" x:Name="dgInProcess">
                <sdk:DataGrid.Columns>
                    <sdk:DataGridTextColumn Header="Start" Binding="{Binding Path=Start}"/>
                    
                    <sdk:DataGridTextColumn Header="Subject" Binding="{Binding Path=Subject}"/>
                    <sdk:DataGridTextColumn Header="StoreName" Binding="{Binding Path=Outlet.OutletName}"/>
                    <sdk:DataGridTextColumn Header="AddressLine1" Binding="{Binding Path=Outlet.Address.AddressLine1}"/>
                    <sdk:DataGridTextColumn Header="AddressLine2" Binding="{Binding Path=Outlet.Address.AddressLine2}"/>
                    <sdk:DataGridTextColumn Header="OwnerName" Binding="{Binding Path=Outlet.OwnerName}"/>
                    <sdk:DataGridTextColumn Header="ContactName" Binding="{Binding Path=Contact.FirstName}"/>
                    <sdk:DataGridTextColumn Header="PhoneNo" Binding="{Binding Path=Outlet.Phone}"/>
                    <sdk:DataGridTextColumn Header="MobileNo" Binding="{Binding Path=Outlet.Mobile}"/>
                   
                    <sdk:DataGridTemplateColumn IsReadOnly="False">
                        <sdk:DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <HyperlinkButton Content="Edit" Click="btnEdit_Click"/>
                            </DataTemplate>
                        </sdk:DataGridTemplateColumn.CellTemplate>
                    </sdk:DataGridTemplateColumn>
                    <sdk:DataGridTemplateColumn IsReadOnly="False">
                        <sdk:DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <HyperlinkButton Content="Resume">
                                    <i:Interaction.Triggers>
                                        <i:EventTrigger EventName="Click">
                                            <cmd:EventToCommand Command="{Binding Source={StaticResource VMLocator}, Path=ScheduleViewModel.ResumeAuditing}" PassEventArgsToCommand="True"/>
                                        </i:EventTrigger>
                                    </i:Interaction.Triggers>
                                </HyperlinkButton>
                            </DataTemplate>
                        </sdk:DataGridTemplateColumn.CellTemplate>
                    </sdk:DataGridTemplateColumn>
                    <sdk:DataGridTemplateColumn IsReadOnly="False">
                        <sdk:DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <HyperlinkButton Content="Delete">
                                    <i:Interaction.Triggers>
                                        <i:EventTrigger EventName="Click">
                                            <cmd:EventToCommand Command="{Binding Source={StaticResource VMLocator}, Path=ScheduleViewModel.DeleteCommand}" PassEventArgsToCommand="True"/>
                                        </i:EventTrigger>
                                    </i:Interaction.Triggers>
                                </HyperlinkButton>
                            </DataTemplate>
                        </sdk:DataGridTemplateColumn.CellTemplate>
                    </sdk:DataGridTemplateColumn>
                </sdk:DataGrid.Columns>
            </sdk:DataGrid>
