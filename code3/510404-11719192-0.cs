    <toolkit:DataGridTemplateColumn Header="Timer" Width="50">
                    <toolkit:DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Content="Start" Click="Button_Click" CommandParameter="{Binding}" />
                        </DataTemplate>
                    </toolkit:DataGridTemplateColumn.CellTemplate>
                </toolkit:DataGridTemplateColumn>
