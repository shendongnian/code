    <DataGridTextColumn Header="Errors" IsReadOnly="True" Binding="{Binding ErrorsReceived}">
                <DataGridTextColumn.CellStyle>
                     <Style>
                         <Style.Triggers>
                             <EventTrigger RoutedEvent="Binding.SourceUpdated">
                                  <BeginStoryboard>
                                      <Storyboard>
                                          <ColorAnimation Storyboard.TargetProperty="Background" From="Red" To="White" Duration="0:0:0.2"/>
                                       </Storyboard>
                                </BeginStoryboard>
                         </EventTrigger>
                           </Style.Triggers>
                   </Style>
               </DataGridTextColumn.CellStyle>
         </DataGridTextColumn >
