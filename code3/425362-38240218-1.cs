     <DataGrid ItemsSource="{Binding PendingChanges}"
              AutoGenerateColumns="False"
              IsReadOnly="True"
              SelectionMode="Extended">
        <i:Interaction.Behaviors>
            <behaviors:MultiSelectGridSelectedItemsBehavior SelectedItems="{Binding SelectedPendingChanges, Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" />
        </i:Interaction.Behaviors>
        <DataGrid.Columns>
            <DataGridCheckBoxColumn Binding="{Binding Path=IsSelected,RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type DataGridRow}}}">
                <DataGridCheckBoxColumn.HeaderTemplate>
                    <DataTemplate>
                        <CheckBox 
                                  behaviors:DataGridSelectAllBehavior.Value="{Binding IsChecked,RelativeSource={RelativeSource Self}}"
                                  behaviors:DataGridSelectAllBehavior.DataGrid="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type DataGrid}}}"/>
                    </DataTemplate>
                </DataGridCheckBoxColumn.HeaderTemplate>
            </DataGridCheckBoxColumn>
            <DataGridTextColumn Header="Name"
                                Width="Auto"
                                Binding="{Binding Name, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" />
            <DataGridTextColumn Header="State"
                                Width="Auto"
                                Binding="{Binding State, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" />
            <DataGridTextColumn Header="Folder"
                                Width="*"
                                Binding="{Binding ParentFolderPath, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" />
        </DataGrid.Columns>
    </DataGrid>
