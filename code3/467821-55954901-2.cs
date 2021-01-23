    <ItemsControl ItemsSource="{Binding Items}">
      <ItemsControl.ItemTemplate>
        <DataTemplate>
          <Grid>
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="*" />
              <ColumnDefinition Width="2*" />
              <ColumnDefinition Width="Auto" />
            </Grid.ColumnDefinitions>
          
            <TextBox Grid.Column="0"
                     Text="{Binding Key, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
            <TextBox Grid.Column="1"
                     Text="{Binding Value, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
          </Grid>
        </DataTemplate>
      </ItemsControl.ItemTemplate>
    </ItemsControl>
