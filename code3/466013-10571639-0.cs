    <Window x:Class="MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:my="clr-namespace:CommandRouting"
        Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="auto"/>
                <RowDefinition/>
                <RowDefinition/>
                <RowDefinition/>
            </Grid.RowDefinitions>
            <Menu IsMainMenu="True">
                <MenuItem x:Name="TestMenuItem" Command="{x:Static my:MainWindow.TestCommand}"/>
            </Menu>
            <GroupBox x:Name="CommandBindingOnControlsGroupBox" Header="CommandBinding on Controls" Grid.Row="1">
                <StackPanel>
                <Button x:Name="CommandBindingOnButtonButton" Command="{x:Static my:MainWindow.TestCommand}" Content="CommandBinding on Button">
                   <Button.CommandBindings>
                        <CommandBinding Command="{x:Static my:MainWindow.TestCommand}" Executed="CommandBinding_Executed" PreviewExecuted="CommandBinding_Executed"/>
                    </Button.CommandBindings>
                </Button>
                    <TextBox x:Name="CommandBindingOnTextBoxTextBox">
                        <TextBox.CommandBindings>
                            <CommandBinding Command="{x:Static my:MainWindow.TestCommand}" Executed="CommandBinding_Executed"/>
                        </TextBox.CommandBindings>
                        <TextBox.InputBindings>
                            <!-- provide alternate keyboard shortcut -->
                            <KeyBinding Key="{x:Static Key.P}" Modifiers="{x:Static ModifierKeys.Control}" Command="{x:Static my:MainWindow.TestCommand}"/>
                        </TextBox.InputBindings>
                    </TextBox>
                    <Button x:Name="CommandTargetOnButtonButton" Command="{x:Static my:MainWindow.TestCommand}" Content="CommandTarget on Button" CommandTarget="{Binding ElementName=CommandBindingOnControlsGroupBox}">
                        <Button.CommandBindings>
                            <CommandBinding Command="{x:Static my:MainWindow.TestCommand}" Executed="CommandBinding_Executed"/>
                        </Button.CommandBindings>
                    </Button>
                </StackPanel>
            </GroupBox>
            <GroupBox x:Name="CommandBindingOnContainerGroupBox" Header="CommandBinding on Container" Grid.Row="2">
                <GroupBox.CommandBindings>
                    <CommandBinding Command="{x:Static my:MainWindow.TestCommand}" PreviewExecuted="CommandBinding_Executed"/>
                </GroupBox.CommandBindings>
                <StackPanel x:Name="CommandBindingOnInnerContainerStackPanel">
                    <StackPanel.CommandBindings>
                        <CommandBinding Command="{x:Static my:MainWindow.TestCommand}" Executed="CommandBinding_Executed"/>
                    </StackPanel.CommandBindings>
                    <Button x:Name="CommandBindingOnContainerButton" Command="{x:Static my:MainWindow.TestCommand}" Content="CommandBinding on Two Containers">
                    </Button>
                    <TextBox x:Name="CommandBindingOnContainerTextBox">
                        <TextBox.InputBindings>
                            <!-- provide alternate keyboard shortcut -->
                            <KeyBinding Key="{x:Static Key.P}" Modifiers="{x:Static ModifierKeys.Control}" Command="{x:Static my:MainWindow.TestCommand}"/>
                        </TextBox.InputBindings>
                    </TextBox>
                </StackPanel>
            </GroupBox>
            <GroupBox x:Name="OtherFocusScopeGroupBox" FocusManager.IsFocusScope="True" Header="Other FocusScope, No CommandBindings" Grid.Row="3">
                <StackPanel >
                    <Button x:Name="OtherFocusScopeButton" Command="{x:Static my:MainWindow.TestCommand}" Content="Other FocusScope">
                    </Button>
                    <TextBox x:Name="OtherFocusScopeTextBox">
                        <TextBox.CommandBindings>
                            <CommandBinding Command="{x:Static my:MainWindow.TestCommand}" Executed="CommandBinding_Executed"/>
                        </TextBox.CommandBindings>
                        <TextBox.InputBindings>
                            <!-- provide alternate keyboard shortcut -->
                            <KeyBinding Key="{x:Static Key.P}" Modifiers="{x:Static ModifierKeys.Control}" Command="{x:Static my:MainWindow.TestCommand}"/>
                        </TextBox.InputBindings>
                    </TextBox>
                </StackPanel>
            </GroupBox>
        </Grid>
    </Window>
