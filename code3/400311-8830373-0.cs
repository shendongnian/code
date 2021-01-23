     <Border Grid.Row="1" Grid.Column="1">
         <ScrollViewer>
             <StackPanel>
                 <DataGrid HorizontalAlignment="Left" ItemsSource="{Binding AwesomeObject, Mode=TwoWay}" Margin="5" AutoGenerateColumns="False">
                     <DataGrid.Columns>
                         <DataGridTextColumn Width="10*" Header="#" Binding="{Binding Number, Mode=TwoWay}"/>
                         <DataGridTextColumn Width="10*" Header="Header" Binding="{Binding Data, Mode=TwoWay}"/>
                         <DataGridTextColumn Width="50*" Header="Long Text" Binding="{Binding SoMuchText, Mode=TwoWay}" ElementStyle="{StaticResource WrappingTextBlock}" EditingElementStyle="{StaticResource WrappingTextBox}"/>
                     </DataGrid.Columns>
                 </DataGrid>
             </StackPanel>
         </ScrollViewer>
     </Border>
