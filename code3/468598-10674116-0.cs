    marker = new Marker( centerLL );  
    marker.icon = new LabelSprite();
    marker.icon.visible = false;
    marker.addEventListener(MapMouseEvent.CLICK, onMapClick); 
    map.addOverlay( marker );
    function onMapClick( e:Event ):void
    {
      if(selectedMarker) 
         selectedMarker.icon.visible = false;
     
      selectedMarker = e.currentTarget as Marker;
      selectedMarker.icon.visible = true;
    }
    public class LabelSprite extends Sprite
    {
      private var labelTextField:TextField;
    
      public function LabelSprite()
      {
        labelTextField = new TextField();
        addChild(labelTextField);
      }
      public function set labelText(value:String):void
      {
        labelTextField.text = value;
      }
    }
