            <toolkit:DataGrid
                     AutoGenerateColumns="False">                
                <toolkit:DataGrid.Columns>
                    <toolkit:DataGridTextColumn 
                             Binding="{Binding SomeProperty}">
                        <toolkit:DataGridTextColumn.ElementStyle>
                            <Style TargetType="{x:Type TextBlock}">
                                <Setter Property="TextWrapping"
                                        Value="Wrap"/>
                            </Style>
                        </toolkit:DataGridTextColumn.ElementStyle>
                    </toolkit:DataGridTextColumn>
                </toolkit:DataGrid.Columns>
            </toolkit:DataGrid>     
