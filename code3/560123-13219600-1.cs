    public class Tabs : CollectionBase
    {
        public FloorsInformation this[int intIndex]
        {
            get
            {
                return (FloorsInformation)InnerList[intIndex];
            }
        }
    }
