    public class PanelVisibilityManager{
        ICollection<Panel> ManagedPanels {get; set;}
        //
        public IDictionary<System.Type, ICollection<Panel>> Switchboard {get; set;}
        public void TogglePanelsFor(System.Type item){
            foreach(var panel in ManagedPanels){
                panel.Visible=false;
                }
            foreach(var panel in Switchboard[item]){
                     panel.Visible=true;              
                }
    }
