    <GridViewColumn Header="File Name" Width="100">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate DataType="{x:Type local:SOFileInfo}">
                            <ItemsControl ItemsSource="{Binding FileNames}" ></ItemsControl>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn Header="File Path" Width="100">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate DataType="{x:Type local:SOFileInfo}">
                            <ItemsControl ItemsSource="{Binding Filepaths}" ></ItemsControl>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
