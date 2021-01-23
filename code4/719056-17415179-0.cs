    <ComboBox x:Name="cmbCommissionTier" 
              ItemsSource="{Binding ListCommissionTier, Mode=TwoWay}" 
              SelectedItem="{Binding SelectedCommissionTier, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" 
              >
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding Path=CommissionValue}"/>
                    <TextBlock Text="%"/>
                </StackPanel>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
