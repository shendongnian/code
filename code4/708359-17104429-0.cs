    <Setter Property="View">
    <Setter.Value>
        <GridView x:Name="WithOutColumn1" AllowsColumnReorder="False">
            <GridViewColumn CellTemplate="{StaticResource Column2Template}">
                <GridViewColumnHeader Content="{Binding ColumnHeader2}" />
            </GridViewColumn>
            <GridViewColumn CellTemplate="{StaticResource Column3Template}">
                <GridViewColumnHeader Content="{Binding ColumnHeader3}" />
            </GridViewColumn>
            <GridViewColumn  CellTemplate="{StaticResource Column4Template}">
                <GridViewColumnHeader Content="{Binding ColumnHeader3}" />
            </GridViewColumn>
            <GridViewColumn  CellTemplate="{StaticResource Column5Template}">
                <GridViewColumnHeader Content="{Binding ColumnHeader3}" />
            </GridViewColumn>
        </GridView>
    </Setter.Value>
