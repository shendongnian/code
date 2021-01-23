	<Window.Resources>
		<DataTemplate DataType="{x:Type my:myClass}">
			<StackPanel>
				<my:AvalonTextEditor x:Name="xmlMessage" SyntaxHighlighting="XML" ShowLineNumbers="True" EditText="{Binding text}" >
					<my:AvalonTextEditor.ContextMenu>
						<ContextMenu x:Name="mymenu1">
							<ContextMenu.Resources>
								<Style TargetType="MenuItem">
									<Setter Property="CommandParameter" Value="{Binding Path=., RelativeSource={RelativeSource AncestorType={x:Type ContextMenu}}}"/>
								</Style>
							</ContextMenu.Resources>
							<MenuItem Header="My Copy" Command="{Binding CopyCommand}" />
							<MenuItem Header="My Paste" Command="{Binding PasteCommand}" />
							<MenuItem Header="My Cut" Command="{Binding CutCommand}" />
							<MenuItem Header="My Undo" Command="{Binding UndoCommand}" />
							<MenuItem Header="My Redo" Command="{Binding RedoCommand}" />
							<Separator />
							<MenuItem Command="Undo" />
							<MenuItem Command="Redo" />
							<Separator/>
							<MenuItem Command="Cut" />
							<MenuItem Command="Copy" />
							<MenuItem Command="Paste" />
						</ContextMenu>
					</my:AvalonTextEditor.ContextMenu>
				</my:AvalonTextEditor>
			</StackPanel>
		</DataTemplate>
	</Window.Resources>
    <StackPanel>
		<DockPanel>
			<ListView ItemsSource="{Binding collection}" />
			<ContentControl Content="{Binding mc}" />
		</DockPanel>
	</StackPanel>
