    <ItemsControl ItemsSource="{Binding Path=Columns, ElementName=dgSearchResult, NotifyOnTargetUpdated=True, NotifyOnSourceUpdated=True}" >
       <ItemsControl.ItemTemplate>
          <DataTemplate >
             <Grid>
              <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto"/>
                <ColumnDefinition Width="5"/>
                <ColumnDefinition Width="Auto"/>
              </Grid.ColumnDefinitions>
                 <CheckBox Content="{Binding Path=Header}" IsChecked="{Binding Path=Visibility, NotifyOnTargetUpdated=True, NotifyOnSourceUpdated=True, Mode=TwoWay, Converter={StaticResource BooleanToHiddenConvertor}}" />
              </Grid>
         </DataTemplate>
      </ItemsControl.ItemTemplate>
