    <DataGridComboBoxColumn Header="Batch Type"
      ItemsSource="{Binding Source={StaticResource methodOfPaymentItemsProvider}}">
      <DataGridComboBoxColumn.ElementStyle>
        <Style TargetType="ComboBox">
            <Setter Property="SelectedIndex" Value="{Binding MethodOfPayment,  UpdateSourceTrigger=PropertyChanged}" />
            <Setter Property="ItemsSource" Value="{Binding Streets, RelativeSource= {RelativeSource FindAncestor,AncestorType=UserControl}, Mode=OneWay}"/>
            <Setter Property="IsReadOnly" Value="True"/>
        </Style>
     </DataGridComboBoxColumn.ElementStyle>
     <DataGridComboBoxColumn.EditingElementStyle>
        <Style TargetType="ComboBox">
            <Setter Property="SelectedIndex" Value="{Binding MethodOfPayment, UpdateSourceTrigger=PropertyChanged}" />
            <Setter Property="ItemsSource" Value="{Binding Streets, RelativeSource={RelativeSource FindAncestor,AncestorType=UserControl}, Mode=OneWay}"/>
         </Style>
     </DataGridComboBoxColumn.EditingElementStyle>
     </DataGridComboBoxColumn>
