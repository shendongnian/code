    <MenuItem Header="Удалить" IsEnabled="{Binding Path=IsDefault, Converter={StaticResource toBoolConverter}}">
        <MenuItem.Style>
            <Style TargetType="MenuItem">
                <EventSetter Event="Click" Handler="OnDeleteClick" />
            </Style>
        </MenuItem.Style>
    </MenuItem>
