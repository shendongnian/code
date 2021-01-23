    <ListView.View>
        <GridView>                                    
            <GridViewColumn Header="1"
                           Width="100">
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <ComboBox ItemsSource="{Binding Path=DataContext.AvailableSids,
                                            RelativeSource={RelativeSource FindAncestor, 
                                            AncestorType={x:Type UserControl}}}"
                                  SelectedItem="{Binding Path=Value1, Mode=TwoWay, 
                                                  UpdateSourceTrigger=PropertyChanged}" />
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
        </GridView>  
    </ListView.View>
