    <DataGridComboBoxColumn DisplayMemberPath="Name">
         <DataGridComboBoxColumn.ElementStyle>
                 <Style>
                    <Setter Property="ComboBox.ItemsSource" Value="{Binding Path=RoadTypes}" />
                 </Style>
          </DataGridComboBoxColumn.ElementStyle>
          <DataGridComboBoxColumn.EditingElementStyle>
                  <Style>
                      <Setter Property="ComboBox.ItemsSource" Value="{Binding Path=RoadTypes}" />
                  </Style>
           </DataGridComboBoxColumn.EditingElementStyle>
      </DataGridComboBoxColumn>
