    <Style x:Key="RenamingTextBox" TargetType="{x:Type TextBox}">
			<Style.Setters>
				<Setter Property="Template">
					<Setter.Value>
						<ControlTemplate TargetType="{x:Type TextBox}">
							<Grid>
								<TextBlock x:Name="block" Visibility="Visible" Text="{TemplateBinding Text}" Margin="1.5"/>
								<TextBox x:Name="box" Visibility="Collapsed" Text="{TemplateBinding Text}"/>
							</Grid>
							<ControlTemplate.Triggers>
								<DataTrigger Binding="{Binding IsRenaming}" Value="true">
									<DataTrigger.Setters>
										<Setter TargetName="block" Property="TextBox.Visibility" Value="Collapsed" />
										<Setter TargetName="box" Property="TextBox.Visibility" Value="Visible" />
									</DataTrigger.Setters>
								</DataTrigger>
							</ControlTemplate.Triggers>
						</ControlTemplate>
					</Setter.Value>
				</Setter>
			</Style.Setters>
		</Style>	
