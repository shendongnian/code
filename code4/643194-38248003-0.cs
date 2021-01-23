    <ComboBox Name="cmbContains" IsEditable="True" IsTextSearchEnabled="false" ItemsSource="{Binding pData}"  DisplayMemberPath="wTitle" Text="{Binding SearchText ,Mode=TwoWay}"  >
      <ComboBox.Triggers>
          <EventTrigger RoutedEvent="TextBoxBase.TextChanged">
              <BeginStoryboard>
                  <Storyboard>
                      <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsDropDownOpen">
                          <DiscreteBooleanKeyFrame Value="True" KeyTime="0:0:0"/>
                      </BooleanAnimationUsingKeyFrames>
                  </Storyboard>
              </BeginStoryboard>
          </EventTrigger>
      </ComboBox.Triggers>
    </ComboBox>
