    <ControlTemplate x:Key="ExpanderToggleButton" TargetType="{x:Type ToggleButton}">
       <Border Name="Border" CornerRadius="0,0,0,0" Background="{x:Null}" BorderBrush="{x:Null}" BorderThickness="0,0,1,0">
           <Grid>
               <Grid.ColumnDefinitions>
                   <ColumnDefinition Width="20" />
                   <ColumnDefinition Width="*" />
               </Grid.ColumnDefinitions>
               <Path Name="Arrow" Fill="#FF4682B4" HorizontalAlignment="Center" VerticalAlignment="Center" Data="M 0 0 L 4 4 L 8 0 Z"/>
               <ContentPresenter Grid.Column="1"/>
           </Grid>
       </Border>
       <ControlTemplate.Triggers>
           ...
       </ControlTemplate.Triggers>
    </ControlTemplate>
    
    <Style TargetType="{x:Type Expander}">
       <Setter Property="Template">
           <Setter.Value>
               <ControlTemplate TargetType="{x:Type Expander}">
                   <Grid>
                       <Grid.RowDefinitions>
                           <RowDefinition Height="Auto"/>
                           <RowDefinition Name="ContentRow" Height="0"/>
                       </Grid.RowDefinitions>
                       <Border Name="Border" Grid.Row="0" Background="{x:Null}" BorderBrush="{x:Null}" BorderThickness="1" CornerRadius="0,0,0,0">
                               <ToggleButton IsChecked="{Binding Path=IsExpanded,Mode=TwoWay,RelativeSource={RelativeSource TemplatedParent}}" OverridesDefaultStyle="True" Template="{StaticResource ExpanderToggleButton}" Background="#FF4682B4">
                                   <ToggleButton.Content>
                                       <ContentPresenter ContentSource="Header" RecognizesAccessKey="True" />
                                   </ToggleButton.Content>
                               </ToggleButton>
                       </Border>
                       <Border Name="Content" Grid.Row="1" Background="{x:Null}" BorderBrush="{x:Null}" BorderThickness="1,0,1,1" CornerRadius="0,0,2,2">
                           <ContentPresenter Margin="4" />
                       </Border>
                   </Grid>
                   <ControlTemplate.Triggers>
                       ....
                   </ControlTemplate.Triggers>
               </ControlTemplate>
           </Setter.Value>
       </Setter>
    </Style>
