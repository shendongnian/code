    editTemplate.Append(@"
    <ComboBox>
    <i:Interaction.Triggers>
        <i:EventTrigger EventName='MouseLeftButtonUp'>
    
            <i:InvokeCommandAction Command='{Binding  DataContext.YourCommand,                                                                                 
               RelativeSource={RelativeSource AncestorType=XXX}}'  
               CommandParameter='{Binding}'/>
        </i:EventTrigger>
    </i:Interaction.Triggers>
    </ComboBox>");
