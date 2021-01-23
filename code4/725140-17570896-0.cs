    <ListBox.ItemTemplate>
                <DataTemplate>
                    <Border x:Name="bord" CornerRadius="5" Margin="2" BorderBrush="LightGray" BorderThickness="3" Background="DarkGray">
                        <StackPanel Margin="5">
                            <TextBlock x:Name="txt" Text="{Binding Name}" FontWeight="Bold"/>
                            <Image Source="{Binding Image}" Height="100"/>
                        </StackPanel>
                    </Border>
   
                </DataTemplate>
    </ListBox.ItemTemplate>
