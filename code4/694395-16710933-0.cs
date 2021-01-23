    <TextBox Text="{Binding Path=CartPayment, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
       <i:Interaction.Triggers>
          <i:EventTrigger EventName="TextChanged">
             <i:InvokeCommandAction Command="{Binding ComputeNewPriceCommand}" />
          </i:EventTrigger>
       <i:Interaction.Triggers>
    </TextBox>
