     <ListBox HorizontalContentAlignment="Stretch">
                    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <Label  Margin="-5, -2,-5,-2" Content="{Binding Item}">
                                <Label.Style>
                                    <Style TargetType="Label">
                                        <Style.Triggers>
                                            <MultiDataTrigger>
                                                <MultiDataTrigger.Conditions>
                                                    <Condition Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type ListBox}},Path=IsFocused}" Value="False"/>
                                                    <Condition Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type ListBoxItem}},Path=IsSelected}" Value="True"/>
                                                </MultiDataTrigger.Conditions>
                                                <Setter Property="Background" Value="CornflowerBlue"/>
                                            </MultiDataTrigger>
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
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                </ListBox>
