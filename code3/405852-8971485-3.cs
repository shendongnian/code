    <!-- Example assumes DataContext of ComboBox is MasterViewModel below -->
    <ComboBox Grid.Row="3" Grid.Column="1" ItemsSource="{Binding Clients}" IsEditable="True">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text={Binding FirstName} Margin="0,0,10,0"/>
                    <TextBlock Text={Binding LastName}/>
                </StackPanel>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
