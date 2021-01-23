    <extToolkit:DataGrid Name="dgData" AutoGenerateColumns="False">
                <extToolkit:DataGrid.RowStyle>
                    <Style TargetType="{x:Type extToolkit:DataGridRow}">
                        <Style.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter Property="ToolTip" Value="{Binding RelativeSource={RelativeSource Mode=Self}, Path=DataContext.ID}" />
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </extToolkit:DataGrid.RowStyle>
                <extToolkit:DataGrid.Columns>
                    <extToolkit:DataGridTextColumn Header="ID" Binding="{Binding ID}" />
                    <extToolkit:DataGridTextColumn Header="First Data" Binding="{Binding FirstData}" />
                    <extToolkit:DataGridTextColumn Header="Second Data" Binding="{Binding SecondData}" />               
                </extToolkit:DataGrid.Columns>
            </extToolkit:DataGrid>
