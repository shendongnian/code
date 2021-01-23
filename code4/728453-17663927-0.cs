    public interface IFuelUpdater {
        void UpdateFuelItemContainerSlots(string[] container, string itemName);
    }
    
    public class MediumOrLowFuelUpdater : IFuelUpdater {
    
        public void UpdateFuelItemContainerSlots(string[] container, string itemName){
            for(i = 0; i < container.Length; i++)
                {
                    if(container[i] == null)
                    {
                        container[i] = item_name;
                    }
                }
        }
    }
       // elsewhere
       
       IFuelUpdater updater = new MediumOrLowFuelUpdater();
       string[] mediumContainer = new string[6];
       string[] lowContainer = new string[6];
    
       updater.UpdateFuelItemSlots(mediumContainer, "*Name Goes Here*");
       updater.UpdateFuelItemSlots(lowContainer, "*Low Name Goes Here*");
