    <ComboBox Margin="5" ItemsSource="{Binding Configs}" SelectedItem="{Binding SelectedConfig, Mode=TwoWay}">
          <i:Interaction.Triggers>
              <i:EventTrigger EventName="SelectionChanged">
                  <i:InvokeCommandAction  Command="{Binding RetrieveSourceLayersCommand}" />
           </i:EventTrigger>
           </i:Interaction.Triggers>
    </ComboBox>
