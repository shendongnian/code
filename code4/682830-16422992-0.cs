    <DataGrid.ColumnHeaderStyle>
                    <Style TargetType="{x:Type DataGridColumnHeader}">
                        <EventSetter Event="Click" Handler="ColumnHeaderClick" />
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <ComboBox ItemsSource="{Binding DataContext.ArticleAttributes, Source={x:Reference control}}">
                                        <l:Interaction.Triggers>
                                            <l:EventTrigger EventName="SelectionChanged">
                                                <l:InvokeCommandAction Command="{Binding DataContext.ArticleAttributeCommand, Source={x:Reference control}}" CommandParameter="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ComboBox}}, Path=SelectedItem}" />
                                            </l:EventTrigger>
                                        </l:Interaction.Triggers>
                                    </ComboBox>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </DataGrid.ColumnHeaderStyle>
