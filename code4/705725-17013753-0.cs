    public partial class FormPrincipal : Form
    {   
        public static string PegarCoordenadas()
        {
            return LatitudeGMS + " | " + LongGMS;
        }
        public static string LatitudeGMS, LongGMS;
        public FormPrincipal(){
             InitializeComponents();
             edtLatitudeGMS.TextChanged += (s,e) => { LatitudeGMS = edtLatitudeGMS.Text;};
             edtlngGMS.TextChanged += (s,e) => {LongGMS = edtlngGMS.Text;};
        }
    }
