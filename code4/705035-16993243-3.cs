    <DataGridTextColumn 
      Header="Ticket Qty" 
      Width="Auto" 
      IsReadOnly="True" >
      <DataGridTextColumn.Binding>
        <MultiBinding Converter="{StaticResource unitConverter}">
          <Binding Path="Column1ViewModelProperty"/>
          <Binding Path="Column2ViewModelProperty" />
          <Binding Path="AdditionalViewModelProperty"/>
        </MultiBinding>
      </DataGridTextColumn.Binding>
    </DataGridTextColumn>
