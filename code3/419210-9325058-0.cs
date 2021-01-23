    <ListView x:Name="_fileNameList" FontSize="12" SourceUpdated="_fileNameList_SourceUpdated" TargetUpdated="_fileNameList_TargetUpdated">
                <ListView.View>
                    <GridView x:Name="FileNameAttributes" >
                        <GridViewColumn  Header="File Name"   Width="200" DisplayMemberBinding="{Binding fileName}"/>
                        <GridViewColumn  Header="Size" Width="80" DisplayMemberBinding="{Binding size}"/>
                        <GridViewColumn  Header="Date" Width="80" DisplayMemberBinding="{Binding date}"/>
                        <GridViewColumn  Header="Time" Width="80" DisplayMemberBinding="{Binding time}"/>
                        <GridViewColumn  Header="New Name" Width="300">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding newFileName}">
                                        <TextBlock.Style>
                                            <Style>
                                                <Setter Property="TextBlock.Foreground" Value="Black"></Setter>
                                                <Style.Triggers>
                                                     <DataTrigger Value="True">
                                                         <DataTrigger.Binding>
                                                             <MultiBinding Converter="{StaticResource EqualityConverter}">
                                                                 <Binding Path="newFileName"></Binding>
                                                                 <Binding Path="fileName"></Binding>
                                                             </MultiBinding>
                                                         </DataTrigger.Binding>
                                            <Setter Property="TextBlock.Foreground" Value="Red"></Setter>
                                        </DataTrigger>
                                                </Style.Triggers>
                                            </Style>
                                        </TextBlock.Style>
                                    </TextBlock>
    
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView>
                </ListView.View>
            </ListView>
