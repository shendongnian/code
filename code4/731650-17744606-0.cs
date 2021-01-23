    <Style TargetType="{x:Type Button}">
    	<Style.Triggers>
    		<Trigger Property="Button.IsPressed" Value="True">
    			<Trigger.ExitActions>
    				<BeginStoryboard>
    					<Storyboard>
    						...
    					</Storyboard>
    				</BeginStoryboard>
    			</Trigger.ExitActions>
    		</Trigger>
    	</Style.Triggers>
    </Style>
