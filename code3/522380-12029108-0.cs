    <GridViewColumn Header="Position">
        <GridViewColumn.CellTemplate>
            <DataTemplate DataType="{x:Type ListViewItem}">
                <TextBlock Name="TextBlockName" Text="{Binding Path=PositionCode}"></TextBlock>
                <DataTemplate.Triggers>
                    <DataTrigger Binding="{Binding PositionCode}" Value="QB">
                        <Setter TargetName="TextBlockName" Property="Foreground" Value="Blue" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding PositionCode}" Value="RB">
                        <Setter TargetName="TextBlockName" Property="Foreground" Value="Green" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding PositionCode}" Value="WR">
                        <Setter TargetName="TextBlockName" Property="Foreground" Value="Red" />
                    </DataTrigger>
                </DataTemplate.Triggers>
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
