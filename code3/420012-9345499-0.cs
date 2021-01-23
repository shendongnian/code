    <Style TargetType="{x:Type MenuItem}">
        <Style.Triggers>
            <Trigger Property="Command" value="{x:Null}">
                <Setter Property="IsEnabled" Value="False"/>
            </Trigger>
        </Style.Triggers>
    </Style>
    ...
    <MenuItem Header="_Compact"
              Command="{Binding Path=CurrentChildViewModel.CompactCommand}" />
    ...
    CompactCommand= new RelayCommand(CompactCommandExecuted, CompactCommandCanExecute);
    private void CompactCommandExecuted(obejct obj)
    {   // Do your business
    }
    private bool CompactCommandCanExecute(object obj)
    {
        // return true if the command is allowed to be executed; otherwise, false.
    }
