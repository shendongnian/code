    <Style x:Key="gbListViewItemStyle"
         TargetType='{x:Type ListViewItem}' BasedOn='{StaticResource BaseListBoxItemStyle}'>
    <Setter Property="ContentTemplate">
        <Setter.Value>
            <DataTemplate>
                <Grid>
                    <Grid.Triggers>
                        <EventTrigger RoutedEvent="ButtonBase.Click">
                            <BeginStoryboard>
                                <Storyboard>
                                    <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="(ToggleButton.IsChecked)" Storyboard.TargetName="pupMenuButton">
                                        <DiscreteBooleanKeyFrame KeyTime="0" Value="False"/>
                                    </BooleanAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Grid.Triggers>
                    <ToggleButton x:Name="pupMenuButton" Command="{Binding Path=ActionCommand}" Style="{DynamicResource FlatToggleButtonStyle}">
                        <Grid>
                            <TextBlock>text</TextBlock>
                        </Grid>
                    </ToggleButton>
                    <Popup Placement="Bottom" AllowsTransparency="True" StaysOpen="False"
                               PopupAnimation="Fade" x:Name="pupMenu" 
                                   IsOpen="{Binding ElementName=pupMenuButton, Path=IsChecked}">
                        <ItemsControl ItemsSource="{Binding Path=ListItems}" >
                            <ItemsControl.ItemsPanel>
                                <ItemsPanelTemplate>
                                    <StackPanel/>
                                </ItemsPanelTemplate>
                            </ItemsControl.ItemsPanel>
                            <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                    <Button Content="{Binding Text1}" Command="{Binding Path=ActionCommand}" CommandParameter="{Binding}" Style="{DynamicResource ButtonStyleFlatBorder}"/>
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                        </ItemsControl>
                    </Popup>
                </Grid>
            </DataTemplate>
        </Setter.Value>
    </Setter>
