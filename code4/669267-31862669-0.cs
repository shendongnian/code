     <ListBox.ItemTemplate>
                        <DataTemplate>
                            <Grid  Margin="-5, -2,-5,-2">
                                <Grid.Style>
                                    <Style TargetType="Grid">
                                        <Style.Triggers>
                                            <MultiDataTrigger>
                                                <MultiDataTrigger.Conditions>
                                                    <Condition Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type ListBox}},Path=IsFocused}" Value="False"/>
                                                    <Condition Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type ListBoxItem}},Path=IsSelected}" Value="True"/>
                                                </MultiDataTrigger.Conditions>
                                                <Setter Property="Background" Value="CornflowerBlue"/>
                                            </MultiDataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </Grid.Style>
                                <Label Content="{Binding Item}">
                                    <Label.Style>
                                        <Style TargetType="Label">
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type ListBoxItem}},Path=IsSelected}" Value="True">
                                                    <Setter Property="Foreground" Value="White"/>
                                                </DataTrigger>
                                                <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type ListBoxItem}},Path=IsSelected}" Value="False">
                                                    <Setter Property="Foreground" Value="Black"/>
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </Label.Style>
                                </Label>
                            </Grid>
                        </DataTemplate>
                    </ListBox.ItemTemplate>
