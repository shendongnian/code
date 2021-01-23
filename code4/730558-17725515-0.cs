            <Grid>
                <DockPanel Grid.Column="0" Grid.Row="0">
                    <TextBlock DockPanel.Dock="Top" Text="Role Groups"/>
                    <DataGrid DockPanel.Dock="Bottom" Name="dgRoleGroups" AutoGenerateColumns="False"
                              CanUserAddRows="True" CanUserDeleteRows="True"
                              HorizontalAlignment="Left" ItemsSource="{Binding ListSecurityUserRoleGroup}">
                        <DataGrid.Columns>
                          
                            <DataGridTemplateColumn Header="Role Group" Width="*">
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <ComboBox ItemsSource="{Binding ListSecurityRoleGroup, 
                                RelativeSource={RelativeSource AncestorType=UserControl}}" SelectedValue="{Binding RoleGroupID,UpdateSourceTrigger=PropertyChanged}"
                                      DisplayMemberPath="Description" SelectedValuePath="ID" IsHitTestVisible="False">
                                     
                                        </ComboBox>
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                                <DataGridTemplateColumn.CellEditingTemplate>
                                    <DataTemplate>
                                        <ComboBox ItemsSource="{Binding ListSecurityRoleGroup, 
                                RelativeSource={RelativeSource AncestorType=UserControl}}" 
                                      DisplayMemberPath="Description" SelectedValuePath="ID"  
                                                  SelectedValue="{Binding RoleGroupID,UpdateSourceTrigger=PropertyChanged}"
                                      />
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellEditingTemplate>
                            </DataGridTemplateColumn>
                        </DataGrid.Columns>
                    </DataGrid>
                </DockPanel>
            </Grid>
