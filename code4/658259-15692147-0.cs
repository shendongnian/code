    <GridViewColumn.CellTemplate>
         <DataTemplate>
              <Grid HorizontalAlignment="Stretch">
                   <CheckBox Name="kioskRequiredCB"  IsChecked="{Binding DefaultKioskAsRequired}"
                             IsEnabled="{Binding DefaultKioskAsHidden, Converter={StaticResource SomeInvertingBooleanConverter}" />
               </Grid>
          </DataTemplate>
     </GridViewColumn.CellTemplate>
    
    <GridViewColumn.CellTemplate>
         <DataTemplate>
              <Grid HorizontalAlignment="Stretch">
                    <CheckBox Name="kioskHiddenCB"  IsChecked="{Binding DefaultKioskAsHidden}"
                              IsEnabled="{Binding DefaultKioskAsRequired, Converter={StaticResource SomeInvertingBooleanConverter}}" />
              </Grid>
          </DataTemplate>
     </GridViewColumn.CellTemplate>
