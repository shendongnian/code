    <Grid>
      <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="*" />
      </Grid.ColumnDefinitions>
      <ListBox Margin="15">
        <ListBox.ItemContainerStyle>
          <Style TargetType="{x:Type ListBoxItem}">
            <Setter Property="Foreground"
                    Value="Blue" />
            <Style.Triggers>
              <MultiTrigger>
                <MultiTrigger.Conditions>
                  <Condition Property="IsSelected"
                              Value="true" />
                  <Condition Property="Selector.IsSelectionActive"
                              Value="false" />
                </MultiTrigger.Conditions>
                <Setter Property="Foreground"
                        Value="Red" />
              </MultiTrigger>
            </Style.Triggers>
          </Style>
        </ListBox.ItemContainerStyle>
        <ListBoxItem Content="A" />
        <ListBoxItem Content="B" />
        <ListBoxItem Content="C" />
      </ListBox>
      <ListBox Grid.Column="1"
                Margin="15">
        <ListBoxItem Content="A" />
        <ListBoxItem Content="B" />
        <ListBoxItem Content="C" />
      </ListBox>
    </Grid>
