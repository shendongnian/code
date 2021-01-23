    public partial class _Default : System.Web.UI.Page
    {
        public double ValueToConvert \
        { 
           get{
               return hfValueToConvert.Value;  
           }
           set{
               hfValueToConvert.Value = this.value.ToString();
           }
        }
        public double ConvertedValue
        { 
           get{
               return hfConvertedValue.Value;  
           }
           set{
               hfConvertedValue.Value = this.value.ToString();
           }
        }
        protected void Page_Load(object sender, EventArgs e){}
        protected void btnUC_Click(object sender, EventArgs e)
        {
            //In this method, the non-static properties ValueToConvert and ConvertedValue
            //get reset. But why?
        }
    }
