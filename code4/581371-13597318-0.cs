     <Style x:Key="DashedTextBoxStyle" BasedOn="{x:Null}" TargetType="{x:Type TextBox}">
			<Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
			<Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.WindowBrushKey}}"/>
			<Setter Property="BorderThickness" Value="1"/>
			<Setter Property="Padding" Value="1"/>
			<Setter Property="AllowDrop" Value="true"/>
			<Setter Property="FocusVisualStyle" Value="{x:Null}"/>
			<Setter Property="ScrollViewer.PanningMode" Value="VerticalFirst"/>
			<Setter Property="Stylus.IsFlicksEnabled" Value="False"/>
			<Setter Property="Template">
				<Setter.Value>
					<ControlTemplate TargetType="{x:Type TextBox}">
						<Border BorderBrush="Black" BorderThickness=".5">
							 <Border BorderBrush="Black" Margin="1" BorderThickness=".5">
									<ScrollViewer x:Name="PART_ContentHost" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
						</Border>
						</Border>
						<ControlTemplate.Triggers>
							<Trigger Property="IsEnabled" Value="false">
								<Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
							</Trigger>
						</ControlTemplate.Triggers>
					</ControlTemplate>
				</Setter.Value>
			</Setter>
			<Style.Triggers>
				<MultiTrigger>
					<MultiTrigger.Conditions>
						<Condition Property="IsInactiveSelectionHighlightEnabled" Value="true"/>
						<Condition Property="IsSelectionActive" Value="false"/>
					</MultiTrigger.Conditions>
					<Setter Property="SelectionBrush" Value="{DynamicResource {x:Static SystemColors.InactiveSelectionHighlightBrushKey}}"/>
				</MultiTrigger>
			</Style.Triggers>
		</Style>
