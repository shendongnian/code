    public class CallingBusinesslayerCode
    {
        public void CallingBusinessLayer()
        {
            // It doesn't show from your code what is returned
            // so here I assume that it is void. 
            new BLLayer().GetBLObject(new BreakingDLayerDependency().GetData("param"));
        }
    }
    public class BreakingDLayerDependency
    {
        public DataSet GetData(string param)
        {
            using (DLayer dl = new DLayer()) //you can of course still do ctor injection here in stead of the new DLayer() 
            {
                return dl.GetData(param);
            }
        }
    }
    public class BLLayer
    {
        public void GetBLObject(DataSet ds)
        {
            // Business Logic using ds here.
        }
    }
