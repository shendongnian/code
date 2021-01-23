    public class PanelVisibilityManager{
        List<Panel> ManagedPanels {get; set;}
        //
        public Dictionary<System.Type, List<Panel>> Switchboard {get; set;}
        public void TogglePanelsFor(System.Type item){
            foreach(var panel in ManagedPanels){
                panel.Visible=false;
                }
            foreach(var panel in Switchboard[item]){
                     panel.Visible=true;              
                }
    }
