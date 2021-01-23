    <GridViewColumn Header="Some Header">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <ContentPresenter Content="{Binding YourViewModelProperty}" />
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
