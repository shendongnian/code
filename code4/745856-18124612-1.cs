	<ContentControl	Grid.Column="2" Grid.Row="3" >
		<ContentControl.Style>
		    <Style>
		        <Style.Triggers>
		            <MultiDataTrigger>
		                <MultiDataTrigger.Conditions>
		                    <Condition Binding="{Binding RelativeSource={RelativeSource self}, Path=IsMouseOver}" Value="True" />
		                    <Condition Binding="{Binding RotorLobes}" Value="1" />
		                </MultiDataTrigger.Conditions>
		                <MultiDataTrigger.EnterActions>
		                    <BeginStoryboard>
		                        <Storyboard>
		                            <DoubleAnimationUsingKeyFrames
		                                        Storyboard.TargetName="StatorMinorRadiusEdit"
		                                        Storyboard.TargetProperty="RenderTransform.X" 
		                                        RepeatBehavior="5x"
		                                        >
		                                <EasingDoubleKeyFrame KeyTime="0:0:0.05" Value="0"/>
		                                <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="3"/>
		                                <EasingDoubleKeyFrame KeyTime="0:0:0.15" Value="0"/>
		                                <EasingDoubleKeyFrame KeyTime="0:0:0.20" Value="-3"/>
		                                <EasingDoubleKeyFrame KeyTime="0:0:0.25" Value="0"/>
		                            </DoubleAnimationUsingKeyFrames>
		                        </Storyboard>
		                    </BeginStoryboard>
		                </MultiDataTrigger.EnterActions>
		            </MultiDataTrigger>
		        </Style.Triggers>
		    </Style>
		</ContentControl.Style>
	
		 <Controls:EditForLength IsEnabled="{Binding Path=LockedFieldEnum.RotorMinorRadiusIsEnabled}" 
		                Value="{Binding Path=RotorMinorRadius}" 
		                >
		  </Controls:EditForLength>
		  
	</ContentControl>
	
