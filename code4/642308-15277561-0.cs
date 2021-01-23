    <Window x:Class="JulienSample.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="500" Width="525">
        <Window.Resources>
            <BitmapImage x:Key="AvatarImage" UriSource="https://shop.blindferret.com/uploads/products/339af7124f5be1c660107332475fd6038742e1e0.jpg" DecodePixelHeight="96" DecodePixelWidth="72"/>
            <BitmapImage x:Key="FlagImage" UriSource="flag.png" DecodePixelHeight="18" DecodePixelWidth="18" />
            <BitmapImage x:Key="FileImage" UriSource="file.png" DecodePixelHeight="18" DecodePixelWidth="18" />
        </Window.Resources>
        <TabControl Width="500">
            <TabItem Header="Julien Rosen">
                <FlowDocumentReader ViewingMode="Scroll" IsPageViewEnabled="False" IsPrintEnabled="False" IsTwoPageViewEnabled="False">
                    <FlowDocument FontFamily="Segoe UI" >
                        <Table BorderBrush="CadetBlue" BorderThickness="1">
                            <Table.Columns>
                                <TableColumn Width="100"/>
                                <TableColumn Width="100" />
                                <TableColumn />
                                <TableColumn Width="100" />
                            </Table.Columns>
                            <TableRowGroup>
                                <TableRow Background="AntiqueWhite">
                                    <TableCell RowSpan="2">
                                        <BlockUIContainer>
                                            <Image Source="{StaticResource AvatarImage}" Width="72" Height="96"/>
                                        </BlockUIContainer>
                                    </TableCell>
    
                                    <TableCell>
                                        <Paragraph>Julien Rosen</Paragraph>
                                    </TableCell>
    
                                    <TableCell Background="Chartreuse"></TableCell>
    
                                    <TableCell>
                                        <Paragraph>07/03/2013</Paragraph>
                                    </TableCell>
                                </TableRow>
    
                                <TableRow Background="Aquamarine">
                                    <TableCell ColumnSpan="3" RowSpan="3">
                                        <Paragraph>
                                            Long messages end at the end at the cell wall instead of continuing underneath the date, regardless of ColumnSpan being set on the TableCell
                                        Long messages end at the end at the cell wall instead of continuing underneath the date, regardless of ColumnSpan being set on the TableCell
                                        </Paragraph>
                                    </TableCell>
                                </TableRow>
                                <TableRow Background="BurlyWood">
                                    <TableCell Background="DarkGreen">
                                        <BlockUIContainer>
                                            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                                                <Image Source="{StaticResource FlagImage}" Height="18" Width="18"/>
                                                <Image Source="{StaticResource FileImage}" Height="18" Width="18"/>
                                            </StackPanel>
                                        </BlockUIContainer>
                                    </TableCell>
                                </TableRow>
                                <TableRow>
                                    <TableCell />
                                </TableRow>
                            </TableRowGroup>
                        </Table>
                        <Table BorderBrush="CadetBlue" BorderThickness="1">
                            <Table.Columns>
                                <TableColumn Width="100"/>
                                <TableColumn Width="100" />
                                <TableColumn />
                                <TableColumn Width="100" />
                            </Table.Columns>
                            <TableRowGroup>
                                <TableRow Background="AntiqueWhite">
                                    <TableCell RowSpan="2">
                                        <BlockUIContainer>
                                            <Image Source="{StaticResource AvatarImage}" Width="72" Height="96"/>
                                        </BlockUIContainer>
                                    </TableCell>
    
                                    <TableCell>
                                        <Paragraph>Julien Rosen</Paragraph>
                                    </TableCell>
    
                                    <TableCell Background="Chartreuse"></TableCell>
    
                                    <TableCell>
                                        <Paragraph>07/03/2013</Paragraph>
                                    </TableCell>
                                </TableRow>
    
                                <TableRow Background="Aquamarine">
                                    <TableCell ColumnSpan="3" RowSpan="3">
                                        <Paragraph>
                                            Long messages end at the end at the cell wall instead of continuing underneath the date, regardless of ColumnSpan being set on the TableCell
                                        Long messages end at the end at the cell wall instead of continuing underneath the date, regardless of ColumnSpan being set on the TableCell
                                        </Paragraph>
                                    </TableCell>
                                </TableRow>
                                <TableRow Background="BurlyWood">
                                    <TableCell Background="DarkGreen">
                                        <BlockUIContainer>
                                            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                                                <Image Source="{StaticResource FlagImage}" Height="18" Width="18"/>
                                                <Image Source="{StaticResource FileImage}" Height="18" Width="18"/>
                                            </StackPanel>
                                        </BlockUIContainer>
                                    </TableCell>
                                </TableRow>
                                <TableRow>
                                    <TableCell />
                                </TableRow>
                            </TableRowGroup>
                        </Table>                </FlowDocument>
                </FlowDocumentReader>
            </TabItem>
    
        </TabControl>
    </Window>
