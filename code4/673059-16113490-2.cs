    <Style TargetType="{x:Type TreeViewItem}">
        <Setter Property="pb:PushBindingManager.StylePushBindings">
            <Setter.Value>
                <pb:PushBindingCollection>
                    <pb:PushBinding TargetDependencyProperty="Controls:TreeViewHelper.IsMouseDirectlyOverItem" 
                                    Path="IsHovered" />
                </pb:PushBindingCollection>
            </Setter.Value>
        </Setter>
    </Style>
