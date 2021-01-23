    <DataGridTemplateColumn.CellEditingTemplate>
      <DataTemplate>
        <TextBox Text="{Binding Number}">
          <i:Interaction.Triggers>
            <i:EventTrigger EventName="GotFocus">
              <i:InvokeCommandAction Command="{Binding CellEditingCommand}" />
            </i:EventTrigger>
          </i:Interaction.Triggers>
        </TextBox>
      </DataTemplate>
    </DataGridTemplateColumn.CellEditingTemplate>
