    <TextBox Text="{Binding ...}" >
      <e:Interaction.Behaviors>
    	<b:AlphaTextBehavior/>
     </e:Interaction.Behaviors>
    </TextBox>
    
    public class DragBehavior : Behavior<TextBox>
    {
     
        protected override void OnAttached()
        {
          // AssociatedObject.TextChanged += 
        }
    }
