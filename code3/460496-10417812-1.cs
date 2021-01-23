    <ItemsControl ItemsSource="{Binding ReceiptItems}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBlock 
                    Text="{Binding Content}" 
                    Foreground="{Binding IsHighlighted, Converter={StaticResource MyColorFromBooleanConverter}}" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
