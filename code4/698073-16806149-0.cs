    <StackPanel>
        <TextBox x:Name="TextBox1" Margin="5,0,5,0" Width="100">
             <i:Interaction.Triggers>
                   <i:EventTrigger EventName="TextChanged">
                        <i:InvokeCommandAction Command="{Binding OnValidateExecute, Mode=OneWay}" CommandParameter="{Binding Text,ElementName=TextBox1}" />
                   </i:EventTrigger>
             </i:Interaction.Triggers>
        </TextBox>
                   
        <Button x:Name="btnSave" Width="120" Height="25" Content="click" IsEnabled="{Binding IsOk}">
             <i:Interaction.Triggers>
                   <i:EventTrigger EventName="Click">
                        <i:InvokeCommandAction Command="{Binding OnSaveExecute}">
                        </i:InvokeCommandAction>
                   </i:EventTrigger>
             </i:Interaction.Triggers>
        </Button>
    </StackPanel>
