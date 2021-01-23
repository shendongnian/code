    <StackPanel>
       <StackPanel.Resources>
           <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
       </StackPanel.Resources>
       <Grid>
           <Grid.ColumnDefinitions>
               <ColumnDefinition/>
               <ColumnDefinition/>
               <ColumnDefinition/>
               <ColumnDefinition/>
               <ColumnDefinition/>
           </Grid.ColumnDefinitions>
           <TextBox Text="0" Grid.Column="0"/>
           <TextBox Text="1" Grid.Column="1"/>
           <TextBox Text="2" Grid.Column="2"/>
           <TextBox Text="3" Grid.Column="3"/>
           <ToggleButton Content="V" Grid.Column="4" x:Name="btnExpander"/>
       </Grid>
       <Grid Visibility="{Binding ElementName=btnExpander, Path=IsChecked, Converter={StaticResource BooleanToVisibilityConverter}}">
           <TextBlock Text="LongText"/>
       </Grid>
    </StackPanel>
