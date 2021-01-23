    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        
        <avalonEdit:TextEditor SyntaxHighlighting="C#" x:Name="TextEditor">
            public class Foo
            {
            }
        </avalonEdit:TextEditor>
        
        <Button Grid.Row="1" Content="Reset syntax highlighting" Click="Button_Click" />
    </Grid>
