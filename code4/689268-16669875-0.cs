	<ResourceDictionary>
		<ResourceDictionary.MergedDictionaries>
			<ResourceDictionary Source="View\Styling\ValidationStyle.xaml"/>
			<ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Colours.xaml" />
			<ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
			<ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
			<ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.AnimatedSingleRowTabControl.xaml" />
			<ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml" />
			<ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml" />
			<ResourceDictionary>
				<Style TargetType="{x:Type TabItem}" BasedOn="{StaticResource {x:Type TabItem}}">
					<Setter Property="HeaderTemplate">
						<Setter.Value>
							<DataTemplate >
								<StackPanel Orientation="Horizontal">
									<TextBlock Text="{Binding FormName}" VerticalAlignment="Center" Margin="2" />
								</StackPanel>
								<DataTemplate.Triggers>
									<DataTrigger Binding="{Binding IsValid}" Value="False" />
								</DataTemplate.Triggers>
							</DataTemplate>
						</Setter.Value>
					</Setter>
				</Style>
			</ResourceDictionary>
		</ResourceDictionary.MergedDictionaries>
	</ResourceDictionary>
